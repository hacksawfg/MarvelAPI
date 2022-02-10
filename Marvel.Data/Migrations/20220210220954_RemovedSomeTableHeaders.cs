using Microsoft.EntityFrameworkCore.Migrations;

namespace Marvel.Data.Migrations
{
    public partial class RemovedSomeTableHeaders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Appearances",
                table: "MarvelCharacters");

            migrationBuilder.DropColumn(
                name: "TeamMembership",
                table: "MarvelCharacters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Appearances",
                table: "MarvelCharacters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeamMembership",
                table: "MarvelCharacters",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
