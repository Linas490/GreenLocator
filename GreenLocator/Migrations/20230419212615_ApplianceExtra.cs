using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenLocator.Migrations
{
    public partial class ApplianceExtra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Appliance",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Appliance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Appliance",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Appliance");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Appliance");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Appliance");
        }
    }
}
