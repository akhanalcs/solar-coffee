using Microsoft.EntityFrameworkCore.Migrations;

namespace SolarCoffee.Data.Migrations
{
    public partial class CorrectProductInventoryTblName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GetProductInventories_Products_ProductId",
                table: "GetProductInventories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GetProductInventories",
                table: "GetProductInventories");

            migrationBuilder.RenameTable(
                name: "GetProductInventories",
                newName: "ProductInventories");

            migrationBuilder.RenameIndex(
                name: "IX_GetProductInventories_ProductId",
                table: "ProductInventories",
                newName: "IX_ProductInventories_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductInventories",
                table: "ProductInventories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInventories_Products_ProductId",
                table: "ProductInventories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInventories_Products_ProductId",
                table: "ProductInventories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductInventories",
                table: "ProductInventories");

            migrationBuilder.RenameTable(
                name: "ProductInventories",
                newName: "GetProductInventories");

            migrationBuilder.RenameIndex(
                name: "IX_ProductInventories_ProductId",
                table: "GetProductInventories",
                newName: "IX_GetProductInventories_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GetProductInventories",
                table: "GetProductInventories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GetProductInventories_Products_ProductId",
                table: "GetProductInventories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
