using BlogWebEntity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogWebData.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            #region SQL de sütun özelliklerini builder.property kullanarak nasıl değiştirebileceğimizi yaptığımız örnekler var içinde 
            //propert(Sütun) seçtik ve nvarchar(max) olan type'ı 150 karakter olarak değişmeye sağlar
            //builder.Property(x => x.Title).HasMaxLength(150);

            //null geçirebilir -- SQL tarafında allow nulls ı işaretlemek demek
            //builder.Property(x => x.Title).IsRequired(false); 

            #endregion


            builder.HasData(new Article
            {
                Id = Guid.NewGuid(),  //Bu işlem DATA SEED'LEMEK DEMEK
                Title = "AspNetCore Title",
                Content = "AspNetCore Content İçeriği burada yazacak",
                ViewCount = 1,              

                CategoryId = Guid.Parse("{33D6D386-C446-469C-B369-5A97E812A967}"),

                ImageId = Guid.Parse("{748EA2A0-EF70-474A-9E15-11B3FC2BDF94}"),

                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new Article
            {
                Id = Guid.NewGuid(),  //Bu işlem DATA SEED'LEMEK DEMEK
                Title = "Visual Studio Title 2",
                Content = "Visual Studio Content İçeriği burada yazacak 2",
                ViewCount = 1,

                CategoryId =  Guid.Parse("{B44CD782-56A2-4C79-9EAC-42E8489A0742}"),

                ImageId = Guid.Parse("{423A809E-67FC-45AA-B4D8-4BA6022D6630}"),

                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            }





            ); 

        }
    }
} 
