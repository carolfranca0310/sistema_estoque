using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Infra.Migrations
{
    /// <inheritdoc />
    public partial class RenameProductInfoIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stock_movement_product_info_product_id",
                table: "stock_movement");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "stock_movement",
                newName: "product_info_id");

            migrationBuilder.RenameIndex(
                name: "IX_stock_movement_product_id",
                table: "stock_movement",
                newName: "IX_stock_movement_product_info_id");

            migrationBuilder.AddForeignKey(
                name: "FK_stock_movement_product_info_product_info_id",
                table: "stock_movement",
                column: "product_info_id",
                principalTable: "product_info",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stock_movement_product_info_product_info_id",
                table: "stock_movement");

            migrationBuilder.RenameColumn(
                name: "product_info_id",
                table: "stock_movement",
                newName: "product_id");

            migrationBuilder.RenameIndex(
                name: "IX_stock_movement_product_info_id",
                table: "stock_movement",
                newName: "IX_stock_movement_product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_stock_movement_product_info_product_id",
                table: "stock_movement",
                column: "product_id",
                principalTable: "product_info",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
