using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasicStandardsForRoundsAndInspectionsAPI.Models.Migrations
{
    /// <inheritdoc />
    public partial class codeAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "SubStandards",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodeAr",
                table: "SubStandards",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionAr",
                table: "SubStandards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "MainStandards",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "MainStandards",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodeAr",
                table: "MainStandards",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TitleAr",
                table: "MainStandards",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "SubStandards");

            migrationBuilder.DropColumn(
                name: "CodeAr",
                table: "SubStandards");

            migrationBuilder.DropColumn(
                name: "DescriptionAr",
                table: "SubStandards");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "MainStandards");

            migrationBuilder.DropColumn(
                name: "CodeAr",
                table: "MainStandards");

            migrationBuilder.DropColumn(
                name: "TitleAr",
                table: "MainStandards");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "MainStandards",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
