using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "price",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Products",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("6d0d807b-e18e-46b2-b12a-5557b264587a"), "Product 1114", 80.0 },
                    { new Guid("7537a3c6-b939-4e6f-9530-43ac571f3749"), "Product 1111", 60.0 },
                    { new Guid("d5401bf6-9671-4456-89f8-10c37df2e514"), "Product 1112", 50.0 },
                    { new Guid("e4453ffc-4836-44d1-b17a-2f31c34292ce"), "Product 1113", 70.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6d0d807b-e18e-46b2-b12a-5557b264587a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7537a3c6-b939-4e6f-9530-43ac571f3749"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d5401bf6-9671-4456-89f8-10c37df2e514"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e4453ffc-4836-44d1-b17a-2f31c34292ce"));

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "id");
        }
    }
}
