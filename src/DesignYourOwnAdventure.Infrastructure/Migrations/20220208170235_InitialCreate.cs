using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignYourOwnAdventure.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adventures",
                columns: table => new
                {
                    BinaryTreeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Root = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adventures", x => x.BinaryTreeId);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BinaryTreeId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Steps = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswerId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Adventures",
                columns: new[] { "BinaryTreeId", "Root" },
                values: new object[] { 1, "{\"Left\":{\"Left\":{\"Left\":{\"Data\":{\"Text\":\"Get it\"}},\"Right\":{\"Data\":{\"Text\":\"Do jumping jacks first!\"}},\"Data\":{\"Text\":\"Are you sure?\"}},\"Right\":{\"Left\":{\"Data\":{\"Text\":\"What are you waiting for? Grab it now.\"}},\"Right\":{\"Data\":{\"Text\":\"Wait till you find a sinful, unforgettable doughnut.\"}},\"Data\":{\"Text\":\"Is it a good donut?\"}},\"Data\":{\"Text\":\"Do I deserve it?\"}},\"Right\":{\"Data\":{\"Text\":\"Maybe you want an apple?\"}},\"Data\":{\"Text\":\"Do I want a Donut?\"}}" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "AnswerId", "BinaryTreeId", "Steps", "UserId" },
                values: new object[] { 1, 1, "[\"L\",\"L\",\"R\",\"L\"]", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DisplayName", "Email" },
                values: new object[] { 1, "Dishan", "dishanrajapaksha@outlook.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adventures");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
