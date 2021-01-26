using Microsoft.EntityFrameworkCore.Migrations;

namespace TCG_Citadel.Data.UserCollection.Migrations
{
    public partial class CreateUserCollectionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserCollectedCards",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Citadel_ID = table.Column<int>(type: "int", nullable: false),
                    Game = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Set = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NonFoil_Collected = table.Column<int>(type: "int", nullable: false),
                    Foil_Collected = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCollectedCards", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCollectedCards");
        }
    }
}
