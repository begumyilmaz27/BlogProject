using BlogWebEntity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogWebData.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            //propert(Sütun) seçtik ve nvarchar(max) olan type'ı 150 karakter olarak değişmeye sağlar
            //builder.Property(x => x.Title).HasMaxLength(150);

            //null geçirebilir -- SQL tarafında allow nulls ı işaretlemek demek
            //builder.Property(x => x.Title).IsRequired(false); 

            builder.HasData(new Article
            {

            });

        }
    }
} 
