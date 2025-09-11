using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Infra.Migrations
{
    /// <inheritdoc />
    public partial class RefactorProductTableAndCreateProductInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "expiration_date",
                table: "products");

            migrationBuilder.DropColumn(
                name: "purchase_date",
                table: "products");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "products",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "brand",
                table: "products",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "weight",
                table: "products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "product_info",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    purchase_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    expiration_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    unit_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    total_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_info", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_info_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_name_brand_weight",
                table: "products",
                columns: new[] { "name", "brand", "weight" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_info_product_id",
                table: "product_info",
                column: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product_info");

            migrationBuilder.DropIndex(
                name: "IX_products_name_brand_weight",
                table: "products");

            migrationBuilder.DropColumn(
                name: "brand",
                table: "products");

            migrationBuilder.DropColumn(
                name: "weight",
                table: "products");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<DateTime>(
                name: "expiration_date",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "purchase_date",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
