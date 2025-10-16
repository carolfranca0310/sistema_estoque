using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultStatusNullableInactivationJustification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "inactivation_justification",
                table: "product_info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "product_info",
                type: "int",
                nullable: false,
                defaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "inactivation_justification",
                table: "product_info");

            migrationBuilder.DropColumn(
                name: "status",
                table: "product_info");
        }
    }
}
