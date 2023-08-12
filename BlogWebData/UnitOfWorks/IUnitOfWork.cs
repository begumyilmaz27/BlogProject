using BlogWebCore.Entities;
using BlogWebData.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebData.UnitOfWorks
{
    /*
     
     * 1. UOW yapısı toplu işlem yaparken karşımıza çıkıyor
     * 2. Entity FrameWork'deki Save etme işlemleri bize çok maliyet sağlamakta ve tek bir alanda kontrol edilememekte. 
              
     * ÖRNEĞİN; bir veriyi güncellerken önce veriyi FindByIDAsync metotumuz ile veriyi bulmamız gerekecek. Uğdate metodumuzu bir yandan çağırmış olacağız. Save işlemi de gerçekleşecek bir taraftan. Bir Image ekliyse eski Image'i aynı anda silmek gerekecek vs. Burada karmaşa oluyor.
     
     * daha güvenli yapı kurmak için, 3 işlem başarılı oldu 1 işlem başarısız olduysa TEK yerden yönetebileceğimiz SAVE metodu olacak ve hata durumunda bize ileti dönecek.
     * 
     * 
     * 
        UnitOfWork faydası; UnitOfWork ve IUnitOfWork ile servislerde burada yazdığımız metotları kullanırken -Kİ SAVE METOT TEMELLİ KULLANDIK UNİTOFWORK'U-  IUnitOfWork'u çağırıp oradan GetRepository'i çağırıp içine istediğimiz Entity'i verip ona göre Repository sınıfı içindeki metotlara ulaşabileceğiz.

        Somut ve Soyut sınıflar kullandığımız için (IUnitOfWork ve UnitOfWork) Data katmanı içindeki Extensions sınıfımızda UnitOfWork'u DependencyInjection yapmalısın; Unutma!

    */


    public interface IUnitOfWork : IAsyncDisposable
    {
        //IRepository'den alıyoruz T parametresi ile
        //GetRepository ismini öneriyor sistem, bu ismi alıyoruz T parametresini ona da yolluyoruz. 
        //Bu T bir class olacak, EntityBase'den türemiş olacak ve new'lenebilecek. 
        IRepository<T> GetRepository<T>() where T : class, IEntityBase, new();


        Task<int> SaveAsync();
        int Save();


    }
}
