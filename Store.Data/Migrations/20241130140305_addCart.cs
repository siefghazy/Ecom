using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Data.Migrations
{
    /// <inheritdoc />
    public partial class addCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_images_imageId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_brandID",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "productsOnCarts",
                columns: table => new
                {
                    productID = table.Column<int>(type: "int", nullable: false),
                    cartID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productsOnCarts", x => new { x.productID, x.cartID });
                    table.ForeignKey(
                        name: "FK_productsOnCarts_Products_productID",
                        column: x => x.productID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productsOnCarts_carts_cartID",
                        column: x => x.cartID,
                        principalTable: "carts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_productsOnCarts_cartID",
                table: "productsOnCarts",
                column: "cartID");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_images_imageId",
                table: "Brands",
                column: "imageId",
                principalTable: "images",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_brandID",
                table: "Products",
                column: "brandID",
                principalTable: "Brands",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_images_imageId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_brandID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "productsOnCarts");

            migrationBuilder.DropTable(
                name: "carts");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_images_imageId",
                table: "Brands",
                column: "imageId",
                principalTable: "images",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_brandID",
                table: "Products",
                column: "brandID",
                principalTable: "Brands",
                principalColumn: "ID");
        }
    }
}
