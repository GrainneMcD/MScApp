using Microsoft.EntityFrameworkCore.Migrations;

namespace MScApp.Migrations
{
    public partial class TestCategoryResultEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestCategoryResults_AppUsers_AppUserId",
                table: "TestCategoryResults");

            migrationBuilder.DropIndex(
                name: "IX_TestCategoryResults_AppUserId",
                table: "TestCategoryResults");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "TestCategoryResults");

            migrationBuilder.DropColumn(
                name: "QuestionCategoryID",
                table: "TestCategoryResults");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "TestCategoryResults");

            migrationBuilder.AddColumn<string>(
                name: "UserIDId",
                table: "TestCategoryResults",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestCategoryResults_UserIDId",
                table: "TestCategoryResults",
                column: "UserIDId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestCategoryResults_AppUsers_UserIDId",
                table: "TestCategoryResults",
                column: "UserIDId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestCategoryResults_AppUsers_UserIDId",
                table: "TestCategoryResults");

            migrationBuilder.DropIndex(
                name: "IX_TestCategoryResults_UserIDId",
                table: "TestCategoryResults");

            migrationBuilder.DropColumn(
                name: "UserIDId",
                table: "TestCategoryResults");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "TestCategoryResults",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionCategoryID",
                table: "TestCategoryResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "TestCategoryResults",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestCategoryResults_AppUserId",
                table: "TestCategoryResults",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestCategoryResults_AppUsers_AppUserId",
                table: "TestCategoryResults",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
