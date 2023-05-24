using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenLocator.Migrations
{
    public partial class CategoryEnummed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appliance_Category_CategoryId",
                table: "Appliance");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Appliance_CategoryId",
                table: "Appliance");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Appliance");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Appliance",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Appliance");

            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "Appliance",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appliance_CategoryId",
                table: "Appliance",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appliance_Category_CategoryId",
                table: "Appliance",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }
    }
}
