using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcurementTracker.Infrastructure.Migrations
{
    public partial class JobApp00007 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfItem",
                table: "PurchaseRequestProductItem",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfItem",
                table: "PurchaseRequestProductItem");
        }
    }
}
