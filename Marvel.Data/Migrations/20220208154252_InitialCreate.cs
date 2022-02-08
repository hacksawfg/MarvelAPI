using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Marvel.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CastAndCrewMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImdbPage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastAndCrewMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarvelCharacters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nemesis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamMembership = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Appearances = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Powers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CastCrewId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarvelCharacters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarvelCharacters_CastAndCrewMembers_CastCrewId",
                        column: x => x.CastCrewId,
                        principalTable: "CastAndCrewMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieBoxOfficeUSD = table.Column<int>(type: "int", nullable: false),
                    MovieDirector = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CastCrewEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movies_CastAndCrewMembers_CastCrewEntityId",
                        column: x => x.CastCrewEntityId,
                        principalTable: "CastAndCrewMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MarvelCharacterEntityMovieEntity",
                columns: table => new
                {
                    MovieCharactersId = table.Column<int>(type: "int", nullable: false),
                    MoviesMovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarvelCharacterEntityMovieEntity", x => new { x.MovieCharactersId, x.MoviesMovieId });
                    table.ForeignKey(
                        name: "FK_MarvelCharacterEntityMovieEntity_MarvelCharacters_MovieCharactersId",
                        column: x => x.MovieCharactersId,
                        principalTable: "MarvelCharacters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarvelCharacterEntityMovieEntity_Movies_MoviesMovieId",
                        column: x => x.MoviesMovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Leader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarvelCharacterEntityId = table.Column<int>(type: "int", nullable: true),
                    MovieEntityMovieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Teams_MarvelCharacters_MarvelCharacterEntityId",
                        column: x => x.MarvelCharacterEntityId,
                        principalTable: "MarvelCharacters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Movies_MovieEntityMovieId",
                        column: x => x.MovieEntityMovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarvelCharacterEntityMovieEntity_MoviesMovieId",
                table: "MarvelCharacterEntityMovieEntity",
                column: "MoviesMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MarvelCharacters_CastCrewId",
                table: "MarvelCharacters",
                column: "CastCrewId",
                unique: true,
                filter: "[CastCrewId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CastCrewEntityId",
                table: "Movies",
                column: "CastCrewEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_MarvelCharacterEntityId",
                table: "Teams",
                column: "MarvelCharacterEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_MovieEntityMovieId",
                table: "Teams",
                column: "MovieEntityMovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarvelCharacterEntityMovieEntity");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "MarvelCharacters");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "CastAndCrewMembers");
        }
    }
}
