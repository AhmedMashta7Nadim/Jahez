using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InfraStractur.Migrations
{
    /// <inheritdoc />
    public partial class adduserRoleSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f7139bf-3640-42e4-90e8-53a501b120f1", "94a62d6f-b09c-4382-bfab-d4c3eef4777c", "Admin", "ADMIN" },
                    { "768b0484-ca23-43d5-beab-da6d942a7a1b", "ffc1115b-edbe-43c7-b557-67cebb2a4511", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f7139bf-3640-42e4-90e8-53a501b120f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "768b0484-ca23-43d5-beab-da6d942a7a1b");
        }
    }
}
