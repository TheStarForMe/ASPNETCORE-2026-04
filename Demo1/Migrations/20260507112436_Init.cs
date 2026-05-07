using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo1.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Population = table.Column<int>(type: "INTEGER", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LandMarks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    CityId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsNice = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandMarks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LandMarks_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Country", "Description", "Name", "Population" },
                values: new object[,]
                {
                    { 1, "USA", "The city that never sleeps", "New York", 8419600 },
                    { 2, "France", "The city of love", "Paris", 2148000 },
                    { 3, "Japan", "The city of the rising sun", "Tokyo", 13929000 }
                });

            migrationBuilder.InsertData(
                table: "LandMarks",
                columns: new[] { "Id", "CityId", "Description", "IsNice", "Name" },
                values: new object[,]
                {
                    { 1, 1, "A colossal neoclassical sculpture on Liberty Island in New York Harbor.", false, "Statue of Liberty" },
                    { 2, 1, "A 102-story Art Deco skyscraper in Midtown Manhattan, New York City.", false, "Empire State Building" },
                    { 3, 2, "A wrought-iron lattice tower on the Champ de Mars in Paris, France.", false, "Eiffel Tower" },
                    { 4, 2, "The world's largest art museum and a historic monument in Paris, France.", false, "Louvre Museum" },
                    { 5, 3, "A communications and observation tower in the Shiba-koen district of Minato, Tokyo, Japan.", false, "Tokyo Tower" },
                    { 6, 3, "An ancient Buddhist temple located in Asakusa, Tokyo, Japan.", false, "Senso-ji Temple" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LandMarks_CityId",
                table: "LandMarks",
                column: "CityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LandMarks");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
