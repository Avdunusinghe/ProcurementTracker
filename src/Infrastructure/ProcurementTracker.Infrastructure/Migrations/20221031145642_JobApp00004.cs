using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcurementTracker.Infrastructure.Migrations
{
    public partial class JobApp00004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequest_Product_ProductId",
                table: "PurchaseRequest");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseRequest_ProductId",
                table: "PurchaseRequest");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "PurchaseRequest");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequestProductItem_ProductId",
                table: "PurchaseRequestProductItem",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequestProductItem_Product_ProductId",
                table: "PurchaseRequestProductItem",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequestProductItem_Product_ProductId",
                table: "PurchaseRequestProductItem");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseRequestProductItem_ProductId",
                table: "PurchaseRequestProductItem");

            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "PurchaseRequest",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequest_ProductId",
                table: "PurchaseRequest",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequest_Product_ProductId",
                table: "PurchaseRequest",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
