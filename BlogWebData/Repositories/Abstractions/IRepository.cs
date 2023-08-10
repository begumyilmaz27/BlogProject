using BlogWebCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebData.Repositories.Abstractions
{
    public interface IRepository<T> where T : class, IEntityBase, new()
    {
        Task AddAsync(T entity);

        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);



        //Liste döndürmeden tek bir nesne döndürmek istediğimizde kullancağımız GetAsync metodunu kullanıcaz. yukarıdakinden tek farkı liste değil bir nesne /değer döndürmesi. yukarıdaki liste döndürecek.
        Task<T> GetAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);




        //Bir tane id yollayıp buna karşılık gelen Entity'yi bulmak için yazdık. 
        Task<T> GetByGuidAsync(Guid id);




        //bir tane değeri update etmek için kullanıcaz
        Task<T> UpdateAsync(T entity);




        //bir veriyi tamamen silme hakkını süperAdmine vericez. Zaten Rol tabanlı bir sistem kullanıcaz Identity kullanıcaz. Farklı rollerdeki kişiler hardDelete yapamicak.
        //IsDeleted yapısı kullandığımız için aslında delete'tın false halini yapmış oluyoruz. Arka planda aslında Update yapmış olucaz
        Task DeleteAsync(T entity);


        //Bool'ın değer dönen T parametresi alıp bool'ın değer dönen predicate fonksiyonu yazdık.
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);



        //'Article tablosu içinde kaç tane nesne var' gibi sorular için aşağıdaki int tipli metodu yazdık. Burada predicate null olabilir yani içinde hiç değer olmayabilir. 
        //Normalde bool yerini İNT yapmıştık ama REPOSİTORY içinde kızdı. tekrar bool tipine çevirdik. AÇIKLAMAYI ORADA YAPTIM
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);







    }
}
