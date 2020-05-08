using Microsoft.EntityFrameworkCore.Migrations;

namespace BrowserAdventures.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_User_UserID",
                table: "InventoryItems");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "InventoryItems",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_User_UserID",
                table: "InventoryItems",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_User_UserID",
                table: "InventoryItems");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "InventoryItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_User_UserID",
                table: "InventoryItems",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
