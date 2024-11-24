using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_brandID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProdTypes_typID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_typID",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "typID",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "brandID",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Products_typID",
                table: "Products",
                column: "typID",
                unique: true,
                filter: "[typID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_brandID",
                table: "Products",
                column: "brandID",
                principalTable: "Brands",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProdTypes_typID",
                table: "Products",
                column: "typID",
                principalTable: "ProdTypes",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_brandID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProdTypes_typID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_typID",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "typID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "brandID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_typID",
                table: "Products",
                column: "typID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_brandID",
                table: "Products",
                column: "brandID",
                principalTable: "Brands",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProdTypes_typID",
                table: "Products",
                column: "typID",
                principalTable: "ProdTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
