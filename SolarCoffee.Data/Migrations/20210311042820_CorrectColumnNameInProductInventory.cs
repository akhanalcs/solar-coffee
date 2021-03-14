using Microsoft.EntityFrameworkCore.Migrations;

namespace SolarCoffee.Data.Migrations
{
    public partial class CorrectColumnNameInProductInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuanityOnHand",
                table: "ProductInventories",
                newName: "QuantityOnHand");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuantityOnHand",
                table: "ProductInventories",
                newName: "QuanityOnHand");
        }
    }
}
