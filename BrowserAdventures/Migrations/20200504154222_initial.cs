﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace BrowserAdventures.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessPoint",
                columns: table => new
                {
                    AccessPointID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<int>(nullable: false),
                    To = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessPoint", x => x.AccessPointID);
                });

            migrationBuilder.CreateTable(
                name: "AccessRequirements",
                columns: table => new
                {
                    AccessRequirementsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessPointID = table.Column<int>(nullable: false),
                    ClosedMessage = table.Column<string>(nullable: true),
                    OpenMessage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessRequirements", x => x.AccessRequirementsID);
                });

            migrationBuilder.CreateTable(
                name: "Consumables",
                columns: table => new
                {
                    ConsumableID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<int>(nullable: false),
                    Heals = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumables", x => x.ConsumableID);
                });

            migrationBuilder.CreateTable(
                name: "Enemy",
                columns: table => new
                {
                    EnemyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnemyName = table.Column<string>(nullable: true),
                    EnemyDescription = table.Column<string>(nullable: true),
                    EnemyHealth = table.Column<int>(nullable: false),
                    EnemyMultipler = table.Column<int>(nullable: false),
                    EnemyDie = table.Column<int>(nullable: false),
                    EnemyModifier = table.Column<int>(nullable: false),
                    EnemyExperience = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemy", x => x.EnemyID);
                });

            migrationBuilder.CreateTable(
                name: "FightLogs",
                columns: table => new
                {
                    FightLogID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    ScreenEnemyID = table.Column<int>(nullable: false),
                    DamageDone = table.Column<int>(nullable: false),
                    Entry = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FightLogs", x => x.FightLogID);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    InventoryItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    ItemID = table.Column<int>(nullable: false),
                    ScreenItemID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => x.InventoryItemID);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemTypeID = table.Column<int>(nullable: false),
                    ItemName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "ItemType",
                columns: table => new
                {
                    ItemTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemType", x => x.ItemTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Screen",
                columns: table => new
                {
                    ScreenID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScreenName = table.Column<string>(nullable: true),
                    ScreenDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screen", x => x.ScreenID);
                });

            migrationBuilder.CreateTable(
                name: "ScreenEnemy",
                columns: table => new
                {
                    ScreenEnemyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScreenID = table.Column<int>(nullable: false),
                    EnemyID = table.Column<int>(nullable: false),
                    ScreenEnemyAction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreenEnemy", x => x.ScreenEnemyID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Screen = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Experience = table.Column<int>(nullable: false),
                    Health = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Weapon",
                columns: table => new
                {
                    WeaponID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<int>(nullable: false),
                    WeaponMultipler = table.Column<int>(nullable: false),
                    WeaponDie = table.Column<int>(nullable: false),
                    WeaponModifier = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapon", x => x.WeaponID);
                });

            migrationBuilder.CreateTable(
                name: "ScreenItem",
                columns: table => new
                {
                    ScreenItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScreenID = table.Column<int>(nullable: false),
                    ItemID = table.Column<int>(nullable: false),
                    ScreenItemDescription = table.Column<string>(nullable: true),
                    ScreenItemTakenDescription = table.Column<string>(nullable: true),
                    ScreenItemAction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreenItem", x => x.ScreenItemID);
                    table.ForeignKey(
                        name: "FK_ScreenItem_Item_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Item",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScreenItem_Screen_ScreenID",
                        column: x => x.ScreenID,
                        principalTable: "Screen",
                        principalColumn: "ScreenID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScreenItem_ItemID",
                table: "ScreenItem",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ScreenItem_ScreenID",
                table: "ScreenItem",
                column: "ScreenID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessPoint");

            migrationBuilder.DropTable(
                name: "AccessRequirements");

            migrationBuilder.DropTable(
                name: "Consumables");

            migrationBuilder.DropTable(
                name: "Enemy");

            migrationBuilder.DropTable(
                name: "FightLogs");

            migrationBuilder.DropTable(
                name: "InventoryItems");

            migrationBuilder.DropTable(
                name: "ItemType");

            migrationBuilder.DropTable(
                name: "ScreenEnemy");

            migrationBuilder.DropTable(
                name: "ScreenItem");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Weapon");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Screen");
        }
    }
}
