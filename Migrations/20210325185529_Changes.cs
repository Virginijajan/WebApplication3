using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication3.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShopId",
                table: "Vegetables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShopId",
                table: "Fruits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShopId",
                table: "Dishwares",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vegetables_ShopId",
                table: "Vegetables",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Fruits_ShopId",
                table: "Fruits",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishwares_ShopId",
                table: "Dishwares",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishwares_Shops_ShopId",
                table: "Dishwares",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fruits_Shops_ShopId",
                table: "Fruits",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vegetables_Shops_ShopId",
                table: "Vegetables",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishwares_Shops_ShopId",
                table: "Dishwares");

            migrationBuilder.DropForeignKey(
                name: "FK_Fruits_Shops_ShopId",
                table: "Fruits");

            migrationBuilder.DropForeignKey(
                name: "FK_Vegetables_Shops_ShopId",
                table: "Vegetables");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropIndex(
                name: "IX_Vegetables_ShopId",
                table: "Vegetables");

            migrationBuilder.DropIndex(
                name: "IX_Fruits_ShopId",
                table: "Fruits");

            migrationBuilder.DropIndex(
                name: "IX_Dishwares_ShopId",
                table: "Dishwares");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "Vegetables");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "Fruits");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "Dishwares");
        }
    }
}
