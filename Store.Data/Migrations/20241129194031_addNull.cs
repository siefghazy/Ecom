using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Data.Migrations
{
    /// <inheritdoc />
    public partial class addNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProdTypes_typID",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProdTypes_typID",
                table: "Products",
                column: "typID",
                principalTable: "ProdTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProdTypes_typID",
                table: "Products");

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
