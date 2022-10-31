using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcurementTracker.Infrastructure.Migrations
{
    public partial class JobApp00002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "PurchaseRequest",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequest_Product_ProductId",
                table: "PurchaseRequest");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseRequest_ProductId",
                table: "PurchaseRequest");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "PurchaseRequest");
        }
    }
}
