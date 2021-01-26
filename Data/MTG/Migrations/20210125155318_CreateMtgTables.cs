using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCG_Citadel.Data.MTG.Migrations
{
    public partial class CreateMtgTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MTG_Cards",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Oracle_ID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Layout = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Image_Small = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Image_Normal = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Image_Large = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Image_Art_Crop = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Digital = table.Column<int>(type: "int", nullable: false),
                    Rarity = table.Column<int>(type: "int", nullable: false),
                    Collector_Number = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Set = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Reprint = table.Column<bool>(type: "bit", nullable: false),
                    Promo = table.Column<bool>(type: "bit", nullable: false),
                    HasFoil = table.Column<bool>(type: "bit", nullable: false),
                    HasNonFoil = table.Column<bool>(type: "bit", nullable: false),
                    ManaCost = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CMC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type_Line = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Oracle_Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Power = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Toughness = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Colors = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Color_Identity = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Keywords = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Loyalty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Legalality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hand_Modifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Artist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Booster = table.Column<bool>(type: "bit", nullable: false),
                    Border_Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Flavor_text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Frame_Effect = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Full_Art = table.Column<bool>(type: "bit", nullable: false),
                    USD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    USD_Foil = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EUR = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EUR_Foil = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MTG_Cards", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MTG_Rarities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "MTG_Sets",
                columns: table => new
                {
                    Citadel_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateReleased = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Set_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Set_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Block_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Block = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parent_set_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Card_Count = table.Column<int>(type: "int", nullable: false),
                    Digital = table.Column<bool>(type: "bit", nullable: false),
                    Foil_Only = table.Column<bool>(type: "bit", nullable: false),
                    NonFoil_Only = table.Column<bool>(type: "bit", nullable: false),
                    Cards_Api_Call = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon_Svg_Uri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MTG_Sets", x => x.Citadel_ID);
                });

            migrationBuilder.CreateTable(
                name: "MTG_SetTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MTG_SetTypes", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MTG_Cards");

            migrationBuilder.DropTable(
                name: "MTG_Rarities");

            migrationBuilder.DropTable(
                name: "MTG_Sets");

            migrationBuilder.DropTable(
                name: "MTG_SetTypes");
        }
    }
}
