using Microsoft.EntityFrameworkCore.Migrations;

namespace FruitAndVegetableWarehouseManagement.Data.Migrations
{
    public partial class UnitToKGRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitsInStock",
                table: "Products",
                newName: "KgsInStock");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "Products",
                newName: "PricePerKg");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "InvoiceProduct",
                newName: "Kilograms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PricePerKg",
                table: "Products",
                newName: "UnitPrice");

            migrationBuilder.RenameColumn(
                name: "KgsInStock",
                table: "Products",
                newName: "UnitsInStock");

            migrationBuilder.RenameColumn(
                name: "Kilograms",
                table: "InvoiceProduct",
                newName: "Quantity");
        }
    }
}
