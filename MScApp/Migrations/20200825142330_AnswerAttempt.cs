using Microsoft.EntityFrameworkCore.Migrations;

namespace MScApp.Migrations
{
    public partial class AnswerAttempt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestAttempts");

            migrationBuilder.CreateTable(
                name: "AnswerAttempts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantID = table.Column<string>(nullable: true),
                    AnswerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerAttempts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AnswerAttempts_Answers_AnswerID",
                        column: x => x.AnswerID,
                        principalTable: "Answers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnswerAttempts_AppUsers_ApplicantID",
                        column: x => x.ApplicantID,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerAttempts_AnswerID",
                table: "AnswerAttempts",
                column: "AnswerID");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerAttempts_ApplicantID",
                table: "AnswerAttempts",
                column: "ApplicantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerAttempts");

            migrationBuilder.CreateTable(
                name: "TestAttempts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerID = table.Column<int>(type: "int", nullable: false),
                    ApplicantID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestAttempts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TestAttempts_Answers_AnswerID",
                        column: x => x.AnswerID,
                        principalTable: "Answers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestAttempts_AppUsers_ApplicantID",
                        column: x => x.ApplicantID,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestAttempts_AnswerID",
                table: "TestAttempts",
                column: "AnswerID");

            migrationBuilder.CreateIndex(
                name: "IX_TestAttempts_ApplicantID",
                table: "TestAttempts",
                column: "ApplicantID");
        }
    }
}
