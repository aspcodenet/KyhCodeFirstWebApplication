using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KyhCodeFirstWebApplication.Migrations
{
    public partial class descr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Players");
        }
    }
}
