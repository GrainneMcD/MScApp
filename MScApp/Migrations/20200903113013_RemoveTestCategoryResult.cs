using Microsoft.EntityFrameworkCore.Migrations;

namespace MScApp.Migrations
{
    public partial class RemoveTestCategoryResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestCategoryResults");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestCategoryResults",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionTypeID = table.Column<int>(type: "int", nullable: false),
                    Result = table.Column<double>(type: "float", nullable: false),
                    TestID = table.Column<int>(type: "int", nullable: true),
                    UserIDId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCategoryResults", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TestCategoryResults_Tests_TestID",
                        column: x => x.TestID,
                        principalTable: "Tests",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestCategoryResults_AppUsers_UserIDId",
                        column: x => x.UserIDId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestCategoryResults_TestID",
                table: "TestCategoryResults",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_TestCategoryResults_UserIDId",
                table: "TestCategoryResults",
                column: "UserIDId");
        }
    }
}
