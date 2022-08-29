using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class CreatingFavoriteTableAndUpdatingUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCasts_Users_UserId",
                table: "MovieCasts");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenres_Users_UserId",
                table: "MovieGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_Trailers_Users_UserId",
                table: "Trailers");

            migrationBuilder.DropIndex(
                name: "IX_Trailers_UserId",
                table: "Trailers");

            migrationBuilder.DropIndex(
                name: "IX_MovieGenres_UserId",
                table: "MovieGenres");

            migrationBuilder.DropIndex(
                name: "IX_MovieCasts_UserId",
                table: "MovieCasts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Trailers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MovieGenres");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MovieCasts");

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => new { x.MovieId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Favorites_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Trailers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MovieGenres",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MovieCasts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trailers_UserId",
                table: "Trailers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_UserId",
                table: "MovieGenres",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCasts_UserId",
                table: "MovieCasts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCasts_Users_UserId",
                table: "MovieCasts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenres_Users_UserId",
                table: "MovieGenres",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trailers_Users_UserId",
                table: "Trailers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
