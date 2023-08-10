using BlogWebCore.Entities;
using BlogWebData.Context;
using BlogWebData.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebData.Repositories.Concretes
{
    //Repository veri tabanı nesnelerinin veri tabanı ile ilişkisini kontrol edecek. Bu yüzden ilk DbContext çağrılmalı
    //Public class Repository<T> where T : class, IEntityBase, new() satırı ne demek ?
    //where T : class, >>>>>>>>>>> yazarak T nesnesinin bir class olduğunu belirtiyoruz ki 26. satırda çağırabililim
    //IEntityBase, new()  >>>>>>>>>>>>>>  Core kurduğumuzda içini boş bıraktığımız Base'i çağırmalıyız. New edebilecek olamalıyız ki getirebililelim
    //Burada nesneler bunun silueti IRepository kısmında. Onu da oluşturup metot isimlerini oraya yazıp metotları Repository içine implemente ettik ve burada metot içlerini doldurduk. 
    public class Repository<T> : IRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext dbContext;

        public Repository(AppDbContext dbContext) //appDbContext CTRL. deyip Field olanı seç
        {
            this.dbContext = dbContext;
        }


        //T her bir Entity'yi kapsıyor (3 tane Entity'im var Category, Article, Image)
        // T yerine TEntity 'de yazıyorlar
        //Table İSMİNDE DBCONTEXT'İ SET ETTİĞİMİZ BİR METOT OLUŞTURDUK YOKSA HER METOT YAZDIĞIMIZDA ÇAĞIRMAMIZ LAZIMDI
        private DbSet<T> Table { get => dbContext.Set<T>(); }





        //liste olarak article'ın dönmesimi istiyoruz ama içinde bir sürü değer olduğu için liste olarak dönmesini istiyoruz. 
        //Expression >> System.Linqu'dan alıyoruz. 
        //func adında fonk. yazmak istiyoruz. Bu fonksiyona bir entity değeri verip bool'an değeri dönmesini istiyoruz. Bool dönmesini isteme nedenimiz where olarak yazmamızdan ötürü. Predicate kısmında bool değer isteme nedenimiz örneğin "Bize tüm Article değerlerini getir ama 'Deleted = false' olanları getir. bu tarz istekler için ayrıca metot yazmak yerine Function ile bunu halledeceğiz. Böylece değer ve liste dönmesini sağlayacağız. 
        //predicate'ı null verme nedenimiz >>> DEFAULT olarak null verdik ki, null geldiğinde ikinci kısım olan includeProperties kısmını kullanabilelim.
        //params ile object dönme koşulunu yazıyoruz. ama birden fazla object dönme koşulunu düşünüp [] diyerek includeProperties ismini veriyoruz. 
        //EF Core'da İnclude metotu var. 
        //GetAllAsync metotdu ve içindeki yazdıklarımız ile aynı anda hem Category'mizi hem Image'imizi Article içine İnclude etmiş olacağız. 
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null , params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table; //IQueryable türünde DbContext nesnesinin set edilmiş halini aldık( Table'ı aldık)

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            //Any diyerek 'includeProperties içinde herhangi bir tane varsa' demek istedik.
            //herhangi bir tane varsa gelecek foreach ile dönecek includeProperties içindekileri ve foreach ile içinde döndüklerini query'ye eşitleyecek. 
            if (includeProperties.Any())
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }

            //yukarıdaki IF DONGUSUNU AŞAĞIDAKİ GİBİ SÜSLÜ PARANTEZ OLMADAN YAZABİLİRİSİN
            //if (includeProperties.Any())
            //    foreach (var item in includeProperties)
            //        query = query.Include(item);


            return await query.ToListAsync();
        }






        //TASK = VOİD 
        //nesne eklendiğinde bana veri döndürmek istemediğimiz için Task kullandık.
        //Void'in async olarak kullanılmış hali olarak düşünebiliriz
        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }



        //Bunu kulllanıyorsak sadece 1 değer döndürmek istiyoruz. 
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate , params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            query = query.Where(predicate);

            if (includeProperties.Any())
                foreach(var item in includeProperties)
                    query = query.Include(item);

            //SingleOrDefaultAsync ve FirstAllDefault kullanabiliriz. Ama FirstorDefault listenin bir tanesini getirir. SingleOrDefault ile liste içinden yüzde yüz değer gelir.
            //hatta SingleAsync kullanmak daha da doğru onu kullandık bu yüzden. 1 tane nesne dönmek istediğimiz için bu daha da doğru bir yaklaşım oldu
            return await query.SingleAsync();
        }




        public async Task<T> GetByGuidAsync(Guid id)
        {
            //FindAsync metodunu kullanrak ID'yi çağırmak yeterli. 
            return await Table.FindAsync(id);
        }




        //Normalde Update işlemleri Async yapıda gerçekleşmez veriye bağlı olarak gerçekleşir. Bir veriye bağlı olduğunu, ID'sine sahip olduğunu kesin olarak ister.
        //Nesnenin listesini isterken async yapıda Update'ini de çağırmek bir çatışmaya neden olur bu yüzden EF CORE tarafında Update'in async metodu yok. 'FindAsync' var mesela yukarıda kullandık... bu tarzda hazır UpdateAsync metodu yok.
        //Biz yapıyı bozmak istemediğimiz iiçin async yapıya çeviricez.
        public async Task<T> UpdateAsync(T entity)
        {
            //() DİYEREK BOŞ BİR METOT OLUŞTURDUK. 
            await Task.Run(() => Table.Update(entity));
            return entity;
        }



        //yukarıdakinin remove halini kullandık. Remove yaptığım için geriye dönecek değer yok 
        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await Table.AnyAsync(predicate);
        }

        //NORMALDE IREpository içinde bool kısmını int tanımlamıştık ama FUNC bool değer döndürmeli ve int'e çevirmeli. 
        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await Table.CountAsync(predicate);
        }
    }
}
