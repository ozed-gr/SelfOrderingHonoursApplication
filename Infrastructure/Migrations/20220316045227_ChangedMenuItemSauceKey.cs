using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ChangedMenuItemSauceKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItemSauces",
                table: "MenuItemSauces");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItemSauces",
                table: "MenuItemSauces",
                columns: new[] { "MenuItemId", "SauceId" });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    TableId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Location = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.TableId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItemSauces",
                table: "MenuItemSauces");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItemSauces",
                table: "MenuItemSauces",
                columns: new[] { "MenuItemId", "Default" });
        }
    }
}
