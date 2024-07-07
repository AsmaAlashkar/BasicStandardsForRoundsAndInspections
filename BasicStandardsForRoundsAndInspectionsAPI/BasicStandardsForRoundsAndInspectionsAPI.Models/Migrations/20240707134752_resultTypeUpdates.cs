using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasicStandardsForRoundsAndInspectionsAPI.Models.Migrations
{
    /// <inheritdoc />
    public partial class resultTypeUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_ResultTypes_ResultTypeId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_SubStandards_SubStandardId",
                table: "Results");

            migrationBuilder.AlterColumn<int>(
                name: "ResultTypeId",
                table: "SubStandards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubStandardId",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_ResultTypes_ResultTypeId",
                table: "Results",
                column: "ResultTypeId",
                principalTable: "ResultTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_SubStandards_SubStandardId",
                table: "Results",
                column: "SubStandardId",
                principalTable: "SubStandards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_ResultTypes_ResultTypeId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_SubStandards_SubStandardId",
                table: "Results");

            migrationBuilder.AlterColumn<int>(
                name: "ResultTypeId",
                table: "SubStandards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SubStandardId",
                table: "Results",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_ResultTypes_ResultTypeId",
                table: "Results",
                column: "ResultTypeId",
                principalTable: "ResultTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_SubStandards_SubStandardId",
                table: "Results",
                column: "SubStandardId",
                principalTable: "SubStandards",
                principalColumn: "Id");
        }
    }
}
