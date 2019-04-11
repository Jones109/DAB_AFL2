using Microsoft.EntityFrameworkCore.Migrations;

namespace DAB_AFL2.Migrations
{
    public partial class TobiasErBoss4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalendarName",
                table: "Calendars");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CalendarName",
                table: "Calendars",
                nullable: true);
        }
    }
}
