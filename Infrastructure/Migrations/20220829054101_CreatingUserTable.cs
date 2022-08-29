using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class CreatingUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salt = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "Users");

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
        }
    }
}
