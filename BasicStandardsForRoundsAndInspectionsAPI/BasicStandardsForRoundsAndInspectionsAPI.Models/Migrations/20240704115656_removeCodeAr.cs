using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasicStandardsForRoundsAndInspectionsAPI.Models.Migrations
{
    /// <inheritdoc />
    public partial class removeCodeAr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeAr",
                table: "SubStandards");

            migrationBuilder.DropColumn(
                name: "CodeAr",
                table: "MainStandards");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodeAr",
                table: "SubStandards",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodeAr",
                table: "MainStandards",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true);
        }
    }
}
