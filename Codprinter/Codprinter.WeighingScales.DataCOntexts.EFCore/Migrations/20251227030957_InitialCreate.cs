using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Codprinter.WeighingScales.DataContext.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeighingScales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateBy = table.Column<Guid>(type: "uuid", nullable: false),
                    WeighingScaleName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    WeighingScaleIp = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    WeighingScalePort = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeighingScales", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeighingScales_WeighingScaleIp",
                table: "WeighingScales",
                column: "WeighingScaleIp",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeighingScales_WeighingScaleName",
                table: "WeighingScales",
                column: "WeighingScaleName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeighingScales");
        }
    }
}
