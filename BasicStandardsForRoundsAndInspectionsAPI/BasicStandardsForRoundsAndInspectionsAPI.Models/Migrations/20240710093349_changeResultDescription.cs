using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasicStandardsForRoundsAndInspectionsAPI.Models.Migrations
{
    /// <inheritdoc />
    public partial class changeResultDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DescriptionAr",
                table: "Results",
                newName: "ResultValueAr");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Results",
                newName: "ResultValue");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ResultValueAr",
                table: "Results",
                newName: "DescriptionAr");

            migrationBuilder.RenameColumn(
                name: "ResultValue",
                table: "Results",
                newName: "Description");
        }
    }
}
