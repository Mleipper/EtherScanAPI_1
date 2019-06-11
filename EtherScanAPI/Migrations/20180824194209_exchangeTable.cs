using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EtherScanAPI.Migrations
{
    public partial class exchangeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExchangeRates",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TimeStamp = table.Column<int>(nullable: false),
                    EtherToUSD = table.Column<double>(nullable: false),
                    ETherToGBP = table.Column<double>(nullable: false),
                    EtherToCNY = table.Column<double>(nullable: false),
                    EtherToAUD = table.Column<double>(nullable: false),
                    EtherToJPY = table.Column<double>(nullable: false),
                    EtherToCAD = table.Column<double>(nullable: false),
                    EtherToEuro = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRates", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExchangeRates");
        }
    }
}
