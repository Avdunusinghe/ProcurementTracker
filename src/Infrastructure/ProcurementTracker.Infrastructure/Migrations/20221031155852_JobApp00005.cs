using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcurementTracker.Infrastructure.Migrations
{
    public partial class JobApp00005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupplierProduct_Product_SupplierId",
                table: "SupplierProduct");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProduct_ProductId",
                table: "SupplierProduct",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierProduct_Product_ProductId",
                table: "SupplierProduct",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupplierProduct_Product_ProductId",
                table: "SupplierProduct");

            migrationBuilder.DropIndex(
                name: "IX_SupplierProduct_ProductId",
                table: "SupplierProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierProduct_Product_SupplierId",
                table: "SupplierProduct",
                column: "SupplierId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
