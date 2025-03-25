using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraStractur.Migrations
{
    /// <inheritdoc />
    public partial class useraddcolcatigryId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategorieId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CategorieId",
                table: "AspNetUsers",
                column: "CategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_categories_CategorieId",
                table: "AspNetUsers",
                column: "CategorieId",
                principalTable: "categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_categories_CategorieId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CategorieId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CategorieId",
                table: "AspNetUsers");
        }
    }
}
