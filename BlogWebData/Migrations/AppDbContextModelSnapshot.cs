﻿// <auto-generated />
using System;
using BlogWebData.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlogWebData.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlogWebEntity.Entities.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ImageId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d3161f59-41b7-44cf-b8e0-43c4961bc7f5"),
                            CategoryId = new Guid("33d6d386-c446-469c-b369-5a97e812a967"),
                            Content = "AspNetCore Content İçeriği burada yazacak",
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2023, 8, 6, 3, 8, 52, 130, DateTimeKind.Local).AddTicks(8813),
                            ImageId = new Guid("748ea2a0-ef70-474a-9e15-11b3fc2bdf94"),
                            IsDeleted = false,
                            Title = "AspNetCore Title",
                            ViewCount = 1
                        },
                        new
                        {
                            Id = new Guid("e70175fe-ddbf-4f41-b23d-ab7bf7cb4fda"),
                            CategoryId = new Guid("b44cd782-56a2-4c79-9eac-42e8489a0742"),
                            Content = "Visual Studio Content İçeriği burada yazacak 2",
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2023, 8, 6, 3, 8, 52, 130, DateTimeKind.Local).AddTicks(8818),
                            ImageId = new Guid("423a809e-67fc-45aa-b4d8-4ba6022d6630"),
                            IsDeleted = false,
                            Title = "Visual Studio Title 2",
                            ViewCount = 1
                        });
                });

            modelBuilder.Entity("BlogWebEntity.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("33d6d386-c446-469c-b369-5a97e812a967"),
                            CategoryId = 0,
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2023, 8, 6, 3, 8, 52, 130, DateTimeKind.Local).AddTicks(8952),
                            IsDeleted = false,
                            Name = "Title"
                        },
                        new
                        {
                            Id = new Guid("b44cd782-56a2-4c79-9eac-42e8489a0742"),
                            CategoryId = 0,
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2023, 8, 6, 3, 8, 52, 130, DateTimeKind.Local).AddTicks(8954),
                            IsDeleted = false,
                            Name = "Visual Studio 2022 Title"
                        });
                });

            modelBuilder.Entity("BlogWebEntity.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = new Guid("748ea2a0-ef70-474a-9e15-11b3fc2bdf94"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2023, 8, 6, 3, 8, 52, 130, DateTimeKind.Local).AddTicks(9023),
                            FileName = "images/testimage",
                            FileType = "jpg",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = new Guid("423a809e-67fc-45aa-b4d8-4ba6022d6630"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2023, 8, 6, 3, 8, 52, 130, DateTimeKind.Local).AddTicks(9026),
                            FileName = "images/vstest",
                            FileType = "png",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("BlogWebEntity.Entities.Article", b =>
                {
                    b.HasOne("BlogWebEntity.Entities.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlogWebEntity.Entities.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("BlogWebEntity.Entities.Image", b =>
                {
                    b.HasOne("BlogWebEntity.Entities.Image", null)
                        .WithMany("Images")
                        .HasForeignKey("ImageId");
                });

            modelBuilder.Entity("BlogWebEntity.Entities.Category", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("BlogWebEntity.Entities.Image", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
