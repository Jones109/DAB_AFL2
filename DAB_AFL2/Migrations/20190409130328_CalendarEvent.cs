using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAB_AFL2.Migrations
{
    public partial class CalendarEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calendar",
                columns: table => new
                {
                    CalendarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendar", x => x.CalendarId);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StarTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    CalendarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Event_Calendar_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendar",
                        principalColumn: "CalendarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 1,
                columns: new[] { "Birthday", "EnrollDate", "GraduateDate" },
                values: new object[] { new DateTime(2019, 4, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 9, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 2,
                columns: new[] { "Birthday", "EnrollDate", "GraduateDate" },
                values: new object[] { new DateTime(2019, 4, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 9, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 3,
                columns: new[] { "Birthday", "EnrollDate", "GraduateDate" },
                values: new object[] { new DateTime(2019, 4, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 9, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_Event_CalendarId",
                table: "Event",
                column: "CalendarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Calendar");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 1,
                columns: new[] { "Birthday", "EnrollDate", "GraduateDate" },
                values: new object[] { new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 2,
                columns: new[] { "Birthday", "EnrollDate", "GraduateDate" },
                values: new object[] { new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 3,
                columns: new[] { "Birthday", "EnrollDate", "GraduateDate" },
                values: new object[] { new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
