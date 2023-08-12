using BlogWebData.Context;
using BlogWebData.Repositories.Abstractions;
using BlogWebData.Repositories.Concretes;
using BlogWebData.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogWebData.Extensions
{
    //Dependency Injection yapıyoruz bu Class ile. 
    //Dependency Injection ve AddScoped yaşam döngüleri için ' https://medium.com/@umutcandan/dependency-injection-nedir-addtransient-addscoped-addsingletion-nas%C4%B1l-%C3%A7al%C4%B1%C5%9F%C4%B1r-f363e522b909 ' yazısına bakabilirsin

    //Program.cs içinde değil burada yapma nedenimiz Program.cs içinde karışıklığa neden olmamak. Bu nedenle service yapımızı yazdık. 
    //Program.cs içinde de servives. kullandık burada da. Sadece ayırdık kendi kodladığımız bölümleri ayrı bir extensions olarak böylece Program.cs'leri temiz tutmuş olduk.
    //Burada yaptığımız işlem sadece Data katmanını etkilediği için de doğru bşr ayrım yapmış olduk. 

    //Program.cs içinde extensions'ını yapmayı unutma

    public static class DataLayerExtensions
    {
        public static IServiceCollection LoadDataLaterExtensions(this IServiceCollection services, IConfiguration config)
        {
            //AddScoped amacı >>> Repositoy ve IRepository sınıflarından IRepository sınıfını çağırdımda Repository nesnesi oluşturması gerektiğini belirttiğimiz bir şey 
            //Yani IRepository'e istek yolladığımızda Repository döndürmüşö olacak.
            //Repository ve IRepository nesnelerimiz Generic Yapıda. Bunların içinde Article istiyorum Article nesnesini getir diye tek tek tanımlanma olmaycak bu nedenle typeof kullandık. 
            //Generic yapı kullandığımız için TypeOf ile belirtmemiz zorunlu.
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            //UnitOfWork yapısında somut ve soyut sınıflar kullandığımız için Repository yapısında olduğu gibi burada da dependency injection yapmalıyız.
            //IUnitOfWork istendiğinde UnitOfWork örneği oluşturmasını istiyoruz. 
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
