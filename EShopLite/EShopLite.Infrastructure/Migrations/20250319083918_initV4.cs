using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EShopLite.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, defaultValue: "https://picsum.photos/200"),
                    Rating = table.Column<double>(type: "float", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Elektronik" },
                    { 2, "Giyim" },
                    { 3, "Mobilya" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "ImageUrl", "Name", "Price", "Rating", "Stock", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, null, "Apple Iphone 12 64 GB", "https://picsum.photos/200", "Iphone 12", 10000m, null, 100, null },
                    { 2, 1, null, "Samsung", "https://picsum.photos/200", "Samsung S21", 9000m, null, 100, null },
                    { 3, 2, null, "Tshirt", "https://picsum.photos/200", "Tshirt", 100m, null, 100, null },
                    { 4, 2, null, "Pantolon", "https://picsum.photos/200", "Pantolon", 200m, null, 100, null },
                    { 5, 3, null, "Masa", "https://picsum.photos/200", "Masa", 500m, null, 100, null },
                    { 6, 3, null, "Sandalye", "https://picsum.photos/200", "Sandalye", 200m, null, 100, null },
                    { 7, 1, null, "Laptop", "https://picsum.photos/200", "Laptop", 15000m, null, 50, null },
                    { 8, 1, null, "Tablet", "https://picsum.photos/200", "Tablet", 5000m, null, 70, null },
                    { 9, 1, null, "Kulaklık", "https://picsum.photos/200", "Kulaklık", 500m, null, 200, null },
                    { 10, 1, null, "Televizyon", "https://picsum.photos/200", "Televizyon", 8000m, null, 30, null },
                    { 11, 2, null, "Kazak", "https://picsum.photos/200", "Kazak", 150m, null, 100, null },
                    { 12, 2, null, "Mont", "https://picsum.photos/200", "Mont", 300m, null, 80, null },
                    { 13, 2, null, "Ayakkabı", "https://picsum.photos/200", "Ayakkabı", 250m, null, 120, null },
                    { 14, 2, null, "Şapka", "https://picsum.photos/200", "Şapka", 50m, null, 150, null },
                    { 15, 2, null, "Ceket", "https://picsum.photos/200", "Ceket", 400m, null, 60, null },
                    { 16, 2, null, "Elbise", "https://picsum.photos/200", "Elbise", 350m, null, 90, null },
                    { 17, 3, null, "Dolap", "https://picsum.photos/200", "Dolap", 2000m, null, 40, null },
                    { 18, 3, null, "Koltuk", "https://picsum.photos/200", "Koltuk", 3000m, null, 20, null },
                    { 19, 3, null, "Sehpa", "https://picsum.photos/200", "Sehpa", 400m, null, 70, null },
                    { 20, 3, null, "Kitaplık", "https://picsum.photos/200", "Kitaplık", 600m, null, 50, null },
                    { 21, 3, null, "Yatak", "https://picsum.photos/200", "Yatak", 2500m, null, 30, null },
                    { 22, 3, null, "Komodin", "https://picsum.photos/200", "Komodin", 300m, null, 60, null },
                    { 23, 3, null, "Lamba", "https://picsum.photos/200", "Lamba", 150m, null, 100, null },
                    { 24, 3, null, "Raf", "https://picsum.photos/200", "Raf", 200m, null, 80, null },
                    { 25, 3, null, "Baza", "https://picsum.photos/200", "Baza", 1000m, null, 40, null },
                    { 26, 3, null, "Perde", "https://picsum.photos/200", "Perde", 200m, null, 70, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
