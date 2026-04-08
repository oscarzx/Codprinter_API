using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Codprinter.Products.DataContext.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddProductSitesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Products_ProductCode",
                table: "Products",
                column: "ProductCode");

            migrationBuilder.CreateTable(
                name: "Product_Site",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Site = table.Column<string>(type: "text", nullable: false),
                    Barcode = table.Column<string>(type: "text", nullable: true),
                    PriceType = table.Column<string>(type: "text", nullable: true),
                    Clearance = table.Column<string>(type: "text", nullable: true),
                    ProductCode = table.Column<string>(type: "text", nullable: false),
                    LegacyProductCode = table.Column<string>(type: "text", nullable: true),
                    ProductName = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Site", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Site_Products_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "Products",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Site_ProductCode",
                table: "Product_Site",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Site_Site_ProductCode",
                table: "Product_Site",
                columns: new[] { "Site", "ProductCode" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product_Site");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Products_ProductCode",
                table: "Products");
        }
    }
}
