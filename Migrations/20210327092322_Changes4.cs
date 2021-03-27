using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication3.Migrations
{
    public partial class Changes4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Vegetables");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Fruits");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Dishwares");

            migrationBuilder.RenameColumn(
                name: "ShopId",
                table: "Shops",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Shops",
                newName: "ShopId");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Vegetables",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Fruits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Dishwares",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
