using Microsoft.EntityFrameworkCore.Migrations;

namespace SolarCoffee.Data.Migrations
{
    public partial class RemovesSecondaryCustomerAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerAddresses_SecondaryAddressId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_SecondaryAddressId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "SecondaryAddressId",
                table: "Customers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SecondaryAddressId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_SecondaryAddressId",
                table: "Customers",
                column: "SecondaryAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerAddresses_SecondaryAddressId",
                table: "Customers",
                column: "SecondaryAddressId",
                principalTable: "CustomerAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
