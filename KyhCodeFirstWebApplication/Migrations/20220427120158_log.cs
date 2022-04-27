using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KyhCodeFirstWebApplication.Migrations
{
    public partial class log : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogEvent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MailingListUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogEvent_MailingListUsers_MailingListUserId",
                        column: x => x.MailingListUserId,
                        principalTable: "MailingListUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogEvent_MailingListUserId",
                table: "LogEvent",
                column: "MailingListUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogEvent");
        }
    }
}
