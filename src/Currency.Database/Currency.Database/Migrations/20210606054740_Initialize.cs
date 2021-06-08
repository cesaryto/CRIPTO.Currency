using Microsoft.EntityFrameworkCore.Migrations;

namespace Currency.Database.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Currency");

            migrationBuilder.CreateTable(
                name: "Coins",
                schema: "Currency",
                columns: table => new
                {
                    coinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nameid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rank = table.Column<int>(type: "int", nullable: false),
                    price_usd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    percent_change_24h = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    percent_change_1h = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    percent_change_7d = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price_btc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    market_cap_usd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    volume24 = table.Column<int>(type: "int", nullable: false),
                    volume24a = table.Column<int>(type: "int", nullable: false),
                    csupply = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tsupply = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    msupply = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coins", x => x.coinId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coins",
                schema: "Currency");
        }
    }
}
