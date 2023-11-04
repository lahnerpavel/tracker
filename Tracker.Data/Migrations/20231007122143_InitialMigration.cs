using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tracker.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DirectorId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movies_People_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "People",
                        principalColumn: "PersonId");
                });

            migrationBuilder.CreateTable(
                name: "GenreMovie",
                columns: table => new
                {
                    GenresGenreId = table.Column<long>(type: "bigint", nullable: false),
                    MoviesMovieId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMovie", x => new { x.GenresGenreId, x.MoviesMovieId });
                    table.ForeignKey(
                        name: "FK_GenreMovie_Genres_GenresGenreId",
                        column: x => x.GenresGenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GenreMovie_Movies_MoviesMovieId",
                        column: x => x.MoviesMovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovieActors",
                columns: table => new
                {
                    ActorsPersonId = table.Column<long>(type: "bigint", nullable: false),
                    MoviesAsActorMovieId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActors", x => new { x.ActorsPersonId, x.MoviesAsActorMovieId });
                    table.ForeignKey(
                        name: "FK_MovieActors_Movies_MoviesAsActorMovieId",
                        column: x => x.MoviesAsActorMovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieActors_People_ActorsPersonId",
                        column: x => x.ActorsPersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { 1L, "sci-fi" },
                    { 2L, "adventure" },
                    { 3L, "action" },
                    { 4L, "romantic" },
                    { 5L, "animated" },
                    { 6L, "comedy" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "Biography", "BirthDate", "Country", "Name", "Role" },
                values: new object[,]
                {
                    { 1L, "Vlastním jménem George Walton Lucas, Jr. se narodil 14. května 1944 v Modestu, Kalifornii. Zde také vystudoval proslulou University of Southern California (USC)...", new DateTime(1944, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "USA", "George Lucas", 1 },
                    { 2L, "Irvin Kershner se narodil ve Filadelfii rodičům židovského původu. Jeho uměleckým zaměřením bylo zpočátku hraní na hudební nástroje...", new DateTime(1923, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "USA", "Irvin Kershner", 1 },
                    { 3L, "Harrison vyrůstal na Chicagském předměstí, kde jeho otec pracoval jako reklamní manažer. Po střední škole začal Harrison studovat filozofii...", new DateTime(1942, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "USA", "Harrison Ford", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovie_MoviesMovieId",
                table: "GenreMovie",
                column: "MoviesMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieActors_MoviesAsActorMovieId",
                table: "MovieActors",
                column: "MoviesAsActorMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies",
                column: "DirectorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreMovie");

            migrationBuilder.DropTable(
                name: "MovieActors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
