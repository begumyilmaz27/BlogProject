using BlogWebData.Mappings;
using BlogWebEntity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebData.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }

        //konfigurasyon için
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //assembly ilgili class'ın bulunduğu katman demek
            //assembly ile IEntityTypeConfiguration'dan kalıtım alan tüm sınıfların yani tüm mapping sınıflarının burada tanımlanmasını sağlıyoruz. istediğimiz kadar mapping yazalım IEntityTypeConfiguration kullandığımız her yerde tanımlamış olduk.
            //IEntityTypeConfiguration ArticleMap içinde kalıtım verdik. 

        }





    }
}
