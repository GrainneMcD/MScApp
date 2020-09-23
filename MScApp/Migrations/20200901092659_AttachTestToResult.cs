using Microsoft.EntityFrameworkCore.Migrations;

namespace MScApp.Migrations
{
    public partial class AttachTestToResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestID",
                table: "TestCategoryResults",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestCategoryResults_TestID",
                table: "TestCategoryResults",
                column: "TestID");

            migrationBuilder.AddForeignKey(
                name: "FK_TestCategoryResults_Tests_TestID",
                table: "TestCategoryResults",
                column: "TestID",
                principalTable: "Tests",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestCategoryResults_Tests_TestID",
                table: "TestCategoryResults");

            migrationBuilder.DropIndex(
                name: "IX_TestCategoryResults_TestID",
                table: "TestCategoryResults");

            migrationBuilder.DropColumn(
                name: "TestID",
                table: "TestCategoryResults");
        }
    }
}
