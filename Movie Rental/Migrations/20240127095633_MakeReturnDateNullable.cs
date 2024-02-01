using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_rental.Migrations
{
    /// <inheritdoc />
    public partial class MakeReturnDateNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnDate",
                table: "Rentals",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "12ef1baa-3601-4c1f-8873-3259bmanager",
                column: "ConcurrencyStamp",
                value: "15b51895-33e8-421b-bb44-28c8eeeef863");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "3ba53cbd-20ad-4684-8709-c662customer",
                column: "ConcurrencyStamp",
                value: "cb0b7056-2280-43ca-937f-1950505ea794");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnDate",
                table: "Rentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "12ef1baa-3601-4c1f-8873-3259bmanager",
                column: "ConcurrencyStamp",
                value: "0bdd45d5-4074-4731-b9a0-6fba3bdc18d4");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "3ba53cbd-20ad-4684-8709-c662customer",
                column: "ConcurrencyStamp",
                value: "f4ff2e36-6bec-424c-a7ac-b938a5006a76");
        }
    }
}
