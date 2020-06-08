using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FruitAndVegetableWarehouseManagement.Data.Migrations
{
    public partial class Supplies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Supplies",
                columns: table => new
                {
                    SupplyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    SupplierCompanyID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplies", x => x.SupplyId);
                    table.ForeignKey(
                        name: "FK_Supplies_Companies_SupplierCompanyID",
                        column: x => x.SupplierCompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupplyProduct",
                columns: table => new
                {
                    SupplyId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Kilograms = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyProduct", x => new { x.SupplyId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_SupplyProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplyProduct_Supplies_SupplyId",
                        column: x => x.SupplyId,
                        principalTable: "Supplies",
                        principalColumn: "SupplyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_SupplierCompanyID",
                table: "Supplies",
                column: "SupplierCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyProduct_ProductId",
                table: "SupplyProduct",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupplyProduct");

            migrationBuilder.DropTable(
                name: "Supplies");
        }
    }
}
