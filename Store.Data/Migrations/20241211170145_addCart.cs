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
            migrationBuilder.AddColumn<string>(
                name: "userID",
                table: "carts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_carts_userID",
                table: "carts",
                column: "userID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_carts_AspNetUsers_userID",
                table: "carts",
                column: "userID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_AspNetUsers_userID",
                table: "carts");

            migrationBuilder.DropIndex(
                name: "IX_carts_userID",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "userID",
                table: "carts");
        }
    }
}
