using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MScApp.Migrations
{
    public partial class TestEntityRemove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Tests_TestID",
                table: "AppUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Tests_TestID",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Questions_TestID",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_TestID",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "TestID",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "TestID",
                table: "AppUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestID",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TestID",
                table: "AppUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TestID",
                table: "Questions",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_TestID",
                table: "AppUsers",
                column: "TestID");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Tests_TestID",
                table: "AppUsers",
                column: "TestID",
                principalTable: "Tests",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Tests_TestID",
                table: "Questions",
                column: "TestID",
                principalTable: "Tests",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
