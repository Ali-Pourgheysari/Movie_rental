using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_rental.Migrations
{
    /// <inheritdoc />
    public partial class MakePaymentRentalOneToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payments_RentalId",
                table: "Payments");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "12ef1baa-3601-4c1f-8873-3259bmanager",
                column: "ConcurrencyStamp",
                value: "c71df739-65fb-45b8-b024-8b14aa50ee4d");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "3ba53cbd-20ad-4684-8709-c662customer",
                column: "ConcurrencyStamp",
                value: "9359ae3e-0511-4acb-bb69-020ca2af9965");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_RentalId",
                table: "Payments",
                column: "RentalId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payments_RentalId",
                table: "Payments");

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

            migrationBuilder.CreateIndex(
                name: "IX_Payments_RentalId",
                table: "Payments",
                column: "RentalId");
        }
    }
}
