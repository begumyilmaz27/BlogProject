using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogWebData.Migrations
{
    /// <inheritdoc />
    public partial class Seedcompleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("33d6d386-c446-469c-b369-5a97e812a967"), 0, "Admin Test", new DateTime(2023, 8, 6, 3, 8, 52, 130, DateTimeKind.Local).AddTicks(8952), null, null, false, null, null, "Title" },
                    { new Guid("b44cd782-56a2-4c79-9eac-42e8489a0742"), 0, "Admin Test", new DateTime(2023, 8, 6, 3, 8, 52, 130, DateTimeKind.Local).AddTicks(8954), null, null, false, null, null, "Visual Studio 2022 Title" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { new Guid("423a809e-67fc-45aa-b4d8-4ba6022d6630"), "Admin Test", new DateTime(2023, 8, 6, 3, 8, 52, 130, DateTimeKind.Local).AddTicks(9026), null, null, "images/vstest", "png", null, false, null, null },
                    { new Guid("748ea2a0-ef70-474a-9e15-11b3fc2bdf94"), "Admin Test", new DateTime(2023, 8, 6, 3, 8, 52, 130, DateTimeKind.Local).AddTicks(9023), null, null, "images/testimage", "jpg", null, false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("d3161f59-41b7-44cf-b8e0-43c4961bc7f5"), new Guid("33d6d386-c446-469c-b369-5a97e812a967"), "AspNetCore Content İçeriği burada yazacak", "Admin Test", new DateTime(2023, 8, 6, 3, 8, 52, 130, DateTimeKind.Local).AddTicks(8813), null, null, new Guid("748ea2a0-ef70-474a-9e15-11b3fc2bdf94"), false, null, null, "AspNetCore Title", 1 },
                    { new Guid("e70175fe-ddbf-4f41-b23d-ab7bf7cb4fda"), new Guid("b44cd782-56a2-4c79-9eac-42e8489a0742"), "Visual Studio Content İçeriği burada yazacak 2", "Admin Test", new DateTime(2023, 8, 6, 3, 8, 52, 130, DateTimeKind.Local).AddTicks(8818), null, null, new Guid("423a809e-67fc-45aa-b4d8-4ba6022d6630"), false, null, null, "Visual Studio Title 2", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("d3161f59-41b7-44cf-b8e0-43c4961bc7f5"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("e70175fe-ddbf-4f41-b23d-ab7bf7cb4fda"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33d6d386-c446-469c-b369-5a97e812a967"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b44cd782-56a2-4c79-9eac-42e8489a0742"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("423a809e-67fc-45aa-b4d8-4ba6022d6630"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("748ea2a0-ef70-474a-9e15-11b3fc2bdf94"));
        }
    }
}
