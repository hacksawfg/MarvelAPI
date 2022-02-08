using Microsoft.EntityFrameworkCore.Migrations;

namespace Marvel.Data.Migrations
{
    public partial class DatabaseJunctionsV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_CastAndCrewMembers_CastCrewEntityId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_CastCrewEntityId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "CastCrewEntityId",
                table: "Movies");

            migrationBuilder.CreateTable(
                name: "CastCrewEntityMovieEntity",
                columns: table => new
                {
                    MovieCastCrewId = table.Column<int>(type: "int", nullable: false),
                    MoviesMovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastCrewEntityMovieEntity", x => new { x.MovieCastCrewId, x.MoviesMovieId });
                    table.ForeignKey(
                        name: "FK_CastCrewEntityMovieEntity_CastAndCrewMembers_MovieCastCrewId",
                        column: x => x.MovieCastCrewId,
                        principalTable: "CastAndCrewMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CastCrewEntityMovieEntity_Movies_MoviesMovieId",
                        column: x => x.MoviesMovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CastCrewEntityMovieEntity_MoviesMovieId",
                table: "CastCrewEntityMovieEntity",
                column: "MoviesMovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CastCrewEntityMovieEntity");

            migrationBuilder.AddColumn<int>(
                name: "CastCrewEntityId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CastCrewEntityId",
                table: "Movies",
                column: "CastCrewEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_CastAndCrewMembers_CastCrewEntityId",
                table: "Movies",
                column: "CastCrewEntityId",
                principalTable: "CastAndCrewMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
