using BlogWebEntity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebData.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category
            {

                Id = Guid.Parse("{33D6D386-C446-469C-B369-5A97E812A967}"),
                Name = "Title",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false


            },
            new Category
            {

                Id = Guid.Parse("{B44CD782-56A2-4C79-9EAC-42E8489A0742}"),
                Name = "Visual Studio 2022 Title",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false

                //DATA SEED'LENİRKEN ARTİCLE İLE BERABER CATEFORY'Sİ DE BERABER OLUŞTURULACAK DEMEK OLUYOR
            }



            );   //DATA SEED'LENİRKEN ARTİCLE İLE BERABER CATEFORY'Sİ DE BERABER OLUŞTURULACAK DEMEK OLUYOR
                 //ayrıca mappleme yapmaya gerek kalmayacak demek oluyor bu şekilde category için)

        }
    }
}
