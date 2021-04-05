using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication3.Migrations
{
    public partial class Changes14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ShopItems_ShopId",
                table: "ShopItems",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ItemId",
                table: "Orders",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShopItems_ItemId",
                table: "Orders",
                column: "ItemId",
                principalTable: "ShopItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopItems_Shops_ShopId",
                table: "ShopItems",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShopItems_ItemId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopItems_Shops_ShopId",
                table: "ShopItems");

            migrationBuilder.DropIndex(
                name: "IX_ShopItems_ShopId",
                table: "ShopItems");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ItemId",
                table: "Orders");
        }
    }
}
