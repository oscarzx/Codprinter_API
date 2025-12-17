using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Codprinter.Labels.DataContexts.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddLabelTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "assets",
                columns: table => new
                {
                    asset_id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    mime_type = table.Column<string>(type: "text", nullable: false),
                    storage_url = table.Column<string>(type: "text", nullable: true),
                    binary_data = table.Column<byte[]>(type: "bytea", nullable: false),
                    checksum = table.Column<string>(type: "text", nullable: false),
                    created_by_user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assets", x => x.asset_id);
                });

            migrationBuilder.CreateTable(
                name: "data_bindings",
                columns: table => new
                {
                    data_binding_id = table.Column<Guid>(type: "uuid", nullable: false),
                    label_variable_id = table.Column<Guid>(type: "uuid", nullable: false),
                    connection_name = table.Column<string>(type: "text", nullable: false),
                    query_type = table.Column<string>(type: "text", nullable: false),
                    table_name = table.Column<string>(type: "text", nullable: true),
                    column_name = table.Column<string>(type: "text", nullable: true),
                    sql_query = table.Column<string>(type: "text", nullable: true),
                    key_mapping_json = table.Column<string>(type: "text", nullable: false),
                    cache_ttl_seconds = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_data_bindings", x => x.data_binding_id);
                });

            migrationBuilder.CreateTable(
                name: "label_elements",
                columns: table => new
                {
                    label_element_id = table.Column<Guid>(type: "uuid", nullable: false),
                    label_template_id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    xmm = table.Column<float>(type: "numeric(9,3)", nullable: false),
                    ymm = table.Column<float>(type: "numeric(9,3)", nullable: false),
                    width_mm = table.Column<float>(type: "numeric(9,3)", nullable: true),
                    height_mm = table.Column<float>(type: "numeric(9,3)", nullable: true),
                    rotation_deg = table.Column<float>(type: "numeric(6,2)", nullable: false, defaultValue: 0f),
                    z_index = table.Column<int>(type: "integer", nullable: false),
                    props_json = table.Column<string>(type: "text", nullable: false),
                    label_variable_id = table.Column<Guid>(type: "uuid", nullable: true),
                    asset_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_label_elements", x => x.label_element_id);
                });

            migrationBuilder.CreateTable(
                name: "label_templates",
                columns: table => new
                {
                    label_template_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    dpi = table.Column<int>(type: "integer", nullable: false),
                    units = table.Column<string>(type: "text", nullable: false),
                    width_mm = table.Column<decimal>(type: "numeric(9,3)", nullable: false),
                    height_mm = table.Column<decimal>(type: "numeric(9,3)", nullable: false),
                    raw_json = table.Column<string>(type: "text", nullable: false),
                    elements_json = table.Column<string>(type: "text", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    created_by_user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_label_templates", x => x.label_template_id);
                });

            migrationBuilder.CreateTable(
                name: "label_variables",
                columns: table => new
                {
                    label_variable_id = table.Column<Guid>(type: "uuid", nullable: false),
                    label_template_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    display_name = table.Column<string>(type: "text", nullable: false),
                    data_type = table.Column<string>(type: "text", nullable: false),
                    source_type = table.Column<string>(type: "text", nullable: false),
                    default_value = table.Column<string>(type: "text", nullable: true),
                    is_required = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    validation_rule_json = table.Column<string>(type: "text", nullable: true),
                    calculation_expr = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_label_variables", x => x.label_variable_id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_assets_type_name",
                table: "assets",
                columns: new[] { "type", "name" });

            migrationBuilder.CreateIndex(
                name: "uq_assets_checksum",
                table: "assets",
                column: "checksum",
                unique: true,
                filter: "checksum IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_data_bindings_variable",
                table: "data_bindings",
                column: "label_variable_id");

            migrationBuilder.CreateIndex(
                name: "ix_label_elements_template_z",
                table: "label_elements",
                columns: new[] { "label_template_id", "z_index" });

            migrationBuilder.CreateIndex(
                name: "ix_label_templates_name",
                table: "label_templates",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_label_variables",
                table: "label_variables",
                columns: new[] { "label_template_id", "name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "assets");

            migrationBuilder.DropTable(
                name: "data_bindings");

            migrationBuilder.DropTable(
                name: "label_elements");

            migrationBuilder.DropTable(
                name: "label_templates");

            migrationBuilder.DropTable(
                name: "label_variables");
        }
    }
}
