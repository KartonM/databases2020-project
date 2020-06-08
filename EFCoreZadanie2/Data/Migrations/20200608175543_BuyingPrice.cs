using Microsoft.EntityFrameworkCore.Migrations;

namespace FruitAndVegetableWarehouseManagement.Data.Migrations
{
    public partial class BuyingPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PricePerKg",
                table: "Products",
                newName: "SellingPricePerKg");

            migrationBuilder.AddColumn<decimal>(
                name: "BuyingPricePerKg",
                table: "Products",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyingPricePerKg",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "SellingPricePerKg",
                table: "Products",
                newName: "PricePerKg");
        }
    }
}
