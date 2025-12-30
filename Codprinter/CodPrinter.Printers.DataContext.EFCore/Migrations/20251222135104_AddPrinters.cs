using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodPrinter.Printers.DataContext.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddPrinters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Printers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    PrinterIp = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    PrinterPort = table.Column<int>(type: "integer", nullable: false),
                    PrinterName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Printers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Printers_PrinterIp",
                table: "Printers",
                column: "PrinterIp",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Printers_PrinterName",
                table: "Printers",
                column: "PrinterName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Printers");
        }
    }
}
