using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo1.Migrations
{
    /// <inheritdoc />
    public partial class NewProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsNice",
                table: "LandMarks",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Population",
                table: "Cities",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsNice",
                table: "LandMarks");

            migrationBuilder.DropColumn(
                name: "Population",
                table: "Cities");
        }
    }
}
