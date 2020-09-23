using Microsoft.EntityFrameworkCore.Migrations;

namespace MScApp.Migrations
{
    public partial class AddTestToAnswerAttempt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestID",
                table: "AnswerAttempts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnswerAttempts_TestID",
                table: "AnswerAttempts",
                column: "TestID");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerAttempts_Tests_TestID",
                table: "AnswerAttempts",
                column: "TestID",
                principalTable: "Tests",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerAttempts_Tests_TestID",
                table: "AnswerAttempts");

            migrationBuilder.DropIndex(
                name: "IX_AnswerAttempts_TestID",
                table: "AnswerAttempts");

            migrationBuilder.DropColumn(
                name: "TestID",
                table: "AnswerAttempts");
        }
    }
}
