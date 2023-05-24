using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenLocator.Migrations
{
    public partial class ReportCategoryMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReportCategory",
                table: "Report",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportCategory",
                table: "Report");
        }
    }
}
