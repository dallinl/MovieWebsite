using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieWebsite.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    MovieID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    Lent_To = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 25, nullable: true),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.MovieID);
                    table.ForeignKey(
                        name: "FK_movies_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 1, "Action/Thriller" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 2, "Drama" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 3, "Family" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 4, "Comedy" });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "MovieID", "CategoryID", "Director", "Edited", "Lent_To", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 1, 1, "Doug Liman", false, "Cousin Ben", "Loved it! Very intense.", "PG-13", "The Bourne Identity", 2002 });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "MovieID", "CategoryID", "Director", "Edited", "Lent_To", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, 2, "John Lee Hancock", true, "", "", "PG-13", "The Blind Side", 2009 });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "MovieID", "CategoryID", "Director", "Edited", "Lent_To", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, 3, "Dan Scanlon", false, "", "even better than the first!", "G", "Monsters University", 2013 });

            migrationBuilder.CreateIndex(
                name: "IX_movies_CategoryID",
                table: "movies",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movies");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
