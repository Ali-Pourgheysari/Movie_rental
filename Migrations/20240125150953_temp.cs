using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Movie_rental.Migrations
{
    /// <inheritdoc />
    public partial class temp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "662d0069-ce01-46f0-a1c8-d1e1845400e0");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "8da61346-9aec-4189-93c8-3a13605c0176");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6519b680-8291-4ada-b4cc-1bc10525726c", "7158dfca-543f-4538-bda9-368f7085c9ec", "Manager", "MANAGER" },
                    { "c15b2dc8-8a8b-431a-96df-1a69fdd7ca8e", "e6d6252d-d337-4b9a-9dbf-69398bfca514", "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "662d0069-ce01-46f0-a1c8-d1e1845400e0", "51478fe9-d052-42f9-b96b-3dae019c60f6", "Customer", "CUSTOMER" },
                    { "8da61346-9aec-4189-93c8-3a13605c0176", "c7e6ebcd-abcd-4b9b-98c8-1f21e7389421", "Manager", "MANAGER" }
                });
        }
    }
}
