using BlogWebData.Repositories.Abstractions;
using BlogWebData.Repositories.Concretes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebData.Extensions
{
    //Dependency Injection yapıyoruz bu Class ile. 
    //Dependency Injection ve AddScoped yaşam döngüleri için ' https://medium.com/@umutcandan/dependency-injection-nedir-addtransient-addscoped-addsingletion-nas%C4%B1l-%C3%A7al%C4%B1%C5%9F%C4%B1r-f363e522b909 ' yazısına bakabilirsin

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
            return services;
        }
    }
}
