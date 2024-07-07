using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasicStandardsForRoundsAndInspectionsAPI.Models.Migrations
{
    /// <inheritdoc />
    public partial class someUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubStandardResults");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Results");

            migrationBuilder.AddColumn<int>(
                name: "ResultTypeId",
                table: "SubStandards",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ResultTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "ResultTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionAr",
                table: "Results",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubStandards_ResultTypeId",
                table: "SubStandards",
                column: "ResultTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubStandards_ResultTypes_ResultTypeId",
                table: "SubStandards",
                column: "ResultTypeId",
                principalTable: "ResultTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubStandards_ResultTypes_ResultTypeId",
                table: "SubStandards");

            migrationBuilder.DropIndex(
                name: "IX_SubStandards_ResultTypeId",
                table: "SubStandards");

            migrationBuilder.DropColumn(
                name: "ResultTypeId",
                table: "SubStandards");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "ResultTypes");

            migrationBuilder.DropColumn(
                name: "DescriptionAr",
                table: "Results");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ResultTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Results",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "SubStandardResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResultId = table.Column<int>(type: "int", nullable: false),
                    SubStandardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubStandardResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubStandardResults_Results_ResultId",
                        column: x => x.ResultId,
                        principalTable: "Results",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubStandardResults_SubStandards_SubStandardId",
                        column: x => x.SubStandardId,
                        principalTable: "SubStandards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubStandardResults_ResultId",
                table: "SubStandardResults",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_SubStandardResults_SubStandardId",
                table: "SubStandardResults",
                column: "SubStandardId");
        }
    }
}
