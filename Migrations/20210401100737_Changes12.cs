using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication3.Migrations
{
    public partial class Changes12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
