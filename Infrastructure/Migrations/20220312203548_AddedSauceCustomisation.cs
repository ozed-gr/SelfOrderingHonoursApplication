using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddedSauceCustomisation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.AddColumn<int>(
                name: "OrderItemsId",
                table: "OrderItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "SauceId",
                table: "OrderItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "OrderItemsId");

            migrationBuilder.CreateTable(
                name: "Sauces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sauces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItemSauces",
                columns: table => new
                {
                    MenuItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Default = table.Column<bool>(type: "INTEGER", nullable: false),
                    SauceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemSauces", x => new { x.MenuItemId, x.Default });
                    table.ForeignKey(
                        name: "FK_MenuItemSauces_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItemSauces_Sauces_SauceId",
                        column: x => x.SauceId,
                        principalTable: "Sauces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MenuItemId",
                table: "OrderItems",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_SauceId",
                table: "OrderItems",
                column: "SauceId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemSauces_SauceId",
                table: "MenuItemSauces",
                column: "SauceId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Sauces_SauceId",
                table: "OrderItems",
                column: "SauceId",
                principalTable: "Sauces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Sauces_SauceId",
                table: "OrderItems");

            migrationBuilder.DropTable(
                name: "MenuItemSauces");

            migrationBuilder.DropTable(
                name: "Sauces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_MenuItemId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_SauceId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "OrderItemsId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "SauceId",
                table: "OrderItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                columns: new[] { "MenuItemId", "OrderId" });
        }
    }
}
