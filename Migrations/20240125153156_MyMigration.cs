using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Movie_rental.Migrations
{
    /// <inheritdoc />
    public partial class MyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "6519b680-8291-4ada-b4cc-1bc10525726c");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "c15b2dc8-8a8b-431a-96df-1a69fdd7ca8e");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5015bef5-e5c0-4340-b71c-4faf19252e0e", "fbbebe53-5a5b-4fd6-8654-47939a572d16", "Manager", "MANAGER" },
                    { "5bf51eaa-0836-4b29-b138-e88c07fa81c6", "23539b77-837f-42ae-ab8b-3a5bd8a0d1f2", "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "5015bef5-e5c0-4340-b71c-4faf19252e0e");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "5bf51eaa-0836-4b29-b138-e88c07fa81c6");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6519b680-8291-4ada-b4cc-1bc10525726c", "7158dfca-543f-4538-bda9-368f7085c9ec", "Manager", "MANAGER" },
                    { "c15b2dc8-8a8b-431a-96df-1a69fdd7ca8e", "e6d6252d-d337-4b9a-9dbf-69398bfca514", "Customer", "CUSTOMER" }
                });
        }
    }
}
