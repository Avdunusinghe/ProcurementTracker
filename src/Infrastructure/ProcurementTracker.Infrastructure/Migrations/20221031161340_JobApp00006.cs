using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcurementTracker.Infrastructure.Migrations
{
    public partial class JobApp00006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequest_User_LastUpdatedById1",
                table: "PurchaseRequest");

            migrationBuilder.RenameColumn(
                name: "LastUpdatedById1",
                table: "PurchaseRequest",
                newName: "StatusChangedById");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequest_LastUpdatedById1",
                table: "PurchaseRequest",
                newName: "IX_PurchaseRequest_StatusChangedById");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequest_User_StatusChangedById",
                table: "PurchaseRequest",
                column: "StatusChangedById",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequest_User_StatusChangedById",
                table: "PurchaseRequest");

            migrationBuilder.RenameColumn(
                name: "StatusChangedById",
                table: "PurchaseRequest",
                newName: "LastUpdatedById1");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequest_StatusChangedById",
                table: "PurchaseRequest",
                newName: "IX_PurchaseRequest_LastUpdatedById1");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequest_User_LastUpdatedById1",
                table: "PurchaseRequest",
                column: "LastUpdatedById1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
