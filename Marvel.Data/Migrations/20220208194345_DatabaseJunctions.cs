using Microsoft.EntityFrameworkCore.Migrations;

namespace Marvel.Data.Migrations
{
    public partial class DatabaseJunctions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_MarvelCharacters_MarvelCharacterEntityId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_MarvelCharacterEntityId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "MarvelCharacterEntityId",
                table: "Teams");

            migrationBuilder.CreateTable(
                name: "MarvelCharacterEntityTeamEntity",
                columns: table => new
                {
                    TeamMembersId = table.Column<int>(type: "int", nullable: false),
                    TeamsTeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarvelCharacterEntityTeamEntity", x => new { x.TeamMembersId, x.TeamsTeamId });
                    table.ForeignKey(
                        name: "FK_MarvelCharacterEntityTeamEntity_MarvelCharacters_TeamMembersId",
                        column: x => x.TeamMembersId,
                        principalTable: "MarvelCharacters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarvelCharacterEntityTeamEntity_Teams_TeamsTeamId",
                        column: x => x.TeamsTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarvelCharacterEntityTeamEntity_TeamsTeamId",
                table: "MarvelCharacterEntityTeamEntity",
                column: "TeamsTeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarvelCharacterEntityTeamEntity");

            migrationBuilder.AddColumn<int>(
                name: "MarvelCharacterEntityId",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_MarvelCharacterEntityId",
                table: "Teams",
                column: "MarvelCharacterEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_MarvelCharacters_MarvelCharacterEntityId",
                table: "Teams",
                column: "MarvelCharacterEntityId",
                principalTable: "MarvelCharacters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
