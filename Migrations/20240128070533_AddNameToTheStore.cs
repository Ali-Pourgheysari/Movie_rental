using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_rental.Migrations
{
    /// <inheritdoc />
    public partial class AddNameToTheStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "12ef1baa-3601-4c1f-8873-3259bmanager",
                column: "ConcurrencyStamp",
                value: "8ab429d8-c7c3-4f04-b94d-b232520274bb");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "3ba53cbd-20ad-4684-8709-c662customer",
                column: "ConcurrencyStamp",
                value: "756b70b8-2793-4ab1-9e6e-3df356d27366");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Stores");

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
    }
}
