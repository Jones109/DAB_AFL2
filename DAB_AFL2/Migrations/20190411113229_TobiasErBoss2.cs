using Microsoft.EntityFrameworkCore.Migrations;

namespace DAB_AFL2.Migrations
{
    public partial class TobiasErBoss2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CalendarName",
                table: "Calendars",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalendarName",
                table: "Calendars");
        }
    }
}
