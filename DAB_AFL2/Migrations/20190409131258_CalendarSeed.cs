using Microsoft.EntityFrameworkCore.Migrations;

namespace DAB_AFL2.Migrations
{
    public partial class CalendarSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Calendar_CalendarId",
                table: "Event");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Calendar",
                table: "Calendar");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "Events");

            migrationBuilder.RenameTable(
                name: "Calendar",
                newName: "Calendars");

            migrationBuilder.RenameIndex(
                name: "IX_Event_CalendarId",
                table: "Events",
                newName: "IX_Events_CalendarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calendars",
                table: "Calendars",
                column: "CalendarId");

            migrationBuilder.InsertData(
                table: "Calendars",
                column: "CalendarId",
                value: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Calendars_CalendarId",
                table: "Events",
                column: "CalendarId",
                principalTable: "Calendars",
                principalColumn: "CalendarId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Calendars_CalendarId",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Calendars",
                table: "Calendars");

            migrationBuilder.DeleteData(
                table: "Calendars",
                keyColumn: "CalendarId",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "Event");

            migrationBuilder.RenameTable(
                name: "Calendars",
                newName: "Calendar");

            migrationBuilder.RenameIndex(
                name: "IX_Events_CalendarId",
                table: "Event",
                newName: "IX_Event_CalendarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calendar",
                table: "Calendar",
                column: "CalendarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Calendar_CalendarId",
                table: "Event",
                column: "CalendarId",
                principalTable: "Calendar",
                principalColumn: "CalendarId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
