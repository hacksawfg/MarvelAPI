using Microsoft.EntityFrameworkCore.Migrations;

namespace Marvel.Data.Migrations
{
    public partial class MoreDatabaseJunctions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Movies_MovieEntityMovieId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_MovieEntityMovieId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "MovieEntityMovieId",
                table: "Teams");

            migrationBuilder.AlterColumn<double>(
                name: "MovieBoxOfficeUSD",
                table: "Movies",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Powers",
                table: "MarvelCharacters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nemesis",
                table: "MarvelCharacters",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MarvelCharacters",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "MovieEntityTeamEntity",
                columns: table => new
                {
                    MovieTeamsTeamId = table.Column<int>(type: "int", nullable: false),
                    TeamMoviesMovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieEntityTeamEntity", x => new { x.MovieTeamsTeamId, x.TeamMoviesMovieId });
                    table.ForeignKey(
                        name: "FK_MovieEntityTeamEntity_Movies_TeamMoviesMovieId",
                        column: x => x.TeamMoviesMovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieEntityTeamEntity_Teams_MovieTeamsTeamId",
                        column: x => x.MovieTeamsTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieEntityTeamEntity_TeamMoviesMovieId",
                table: "MovieEntityTeamEntity",
                column: "TeamMoviesMovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieEntityTeamEntity");

            migrationBuilder.AddColumn<int>(
                name: "MovieEntityMovieId",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MovieBoxOfficeUSD",
                table: "Movies",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Powers",
                table: "MarvelCharacters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nemesis",
                table: "MarvelCharacters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MarvelCharacters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_MovieEntityMovieId",
                table: "Teams",
                column: "MovieEntityMovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Movies_MovieEntityMovieId",
                table: "Teams",
                column: "MovieEntityMovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
