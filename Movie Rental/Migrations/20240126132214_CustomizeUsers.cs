using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_rental.Migrations
{
    /// <inheritdoc />
    public partial class CustomizeUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_User_CustomerId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_User_CustomerId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_User_CustomerId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_User_ManagerId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "DelayCount",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "User");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Payments",
                type: "decimal(8,2)",
                precision: 8,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "RentalRate",
                table: "Films",
                type: "decimal(8,2)",
                precision: 8,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DelayCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manager_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "12ef1baa-3601-4c1f-8873-3259bmanager",
                column: "ConcurrencyStamp",
                value: "6ec3a043-dd82-4b28-89cf-45acc8240e16");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "3ba53cbd-20ad-4684-8709-c662customer",
                column: "ConcurrencyStamp",
                value: "3d45fd57-d9c8-4058-b9da-df8ebcf59a31");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Customer_CustomerId",
                table: "Payments",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Customer_CustomerId",
                table: "Rentals",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customer_CustomerId",
                table: "Reservations",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Manager_ManagerId",
                table: "Stores",
                column: "ManagerId",
                principalTable: "Manager",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Customer_CustomerId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Customer_CustomerId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customer_CustomerId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Manager_ManagerId",
                table: "Stores");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.AddColumn<int>(
                name: "DelayCount",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Payments",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)",
                oldPrecision: 8,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "RentalRate",
                table: "Films",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)",
                oldPrecision: 8,
                oldScale: 2);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "12ef1baa-3601-4c1f-8873-3259bmanager",
                column: "ConcurrencyStamp",
                value: "214a0a70-74c1-4773-aba5-248c126a1939");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "3ba53cbd-20ad-4684-8709-c662customer",
                column: "ConcurrencyStamp",
                value: "290401e0-0d5a-40e7-973b-51db36cb4981");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_User_CustomerId",
                table: "Payments",
                column: "CustomerId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_User_CustomerId",
                table: "Rentals",
                column: "CustomerId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_User_CustomerId",
                table: "Reservations",
                column: "CustomerId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_User_ManagerId",
                table: "Stores",
                column: "ManagerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
