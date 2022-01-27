using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieWebsite.Migrations
{
    public partial class Submission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    MovieID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    Lent_To = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.MovieID);
                });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "MovieID", "Category", "Director", "Edited", "Lent_To", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 1, "Action/Thriller", "Doug Liman", false, "Cousin Ben", "Loved it! Very intense.", "PG-13", "The Bourne Identity", 2002 });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "MovieID", "Category", "Director", "Edited", "Lent_To", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, "Drama", "John Lee Hancock", true, "", "", "PG-13", "The Blind Side", 2009 });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "MovieID", "Category", "Director", "Edited", "Lent_To", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, "Family", "Dan Scanlon", false, "", "even better than the first!", "G", "Monsters University", 2013 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movies");
        }
    }
}
