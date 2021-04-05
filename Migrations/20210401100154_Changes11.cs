using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication3.Migrations
{
    public partial class Changes11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Orders",
                newName: "ItemName");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ItemName",
                table: "Orders",
                newName: "Name");

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
    }
}
