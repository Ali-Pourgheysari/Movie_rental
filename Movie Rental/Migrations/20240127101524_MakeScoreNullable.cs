using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_rental.Migrations
{
    /// <inheritdoc />
    public partial class MakeScoreNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Score",
                table: "Rentals",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "12ef1baa-3601-4c1f-8873-3259bmanager",
                column: "ConcurrencyStamp",
                value: "405d5319-46ba-45d7-8cba-4b0abb39b417");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "3ba53cbd-20ad-4684-8709-c662customer",
                column: "ConcurrencyStamp",
                value: "e7206a99-b995-4fb1-b455-07a88705b9ed");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Score",
                table: "Rentals",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

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
    }
}
