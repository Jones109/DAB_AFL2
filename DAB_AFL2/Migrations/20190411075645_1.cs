using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAB_AFL2.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 1,
                columns: new[] { "Birthday", "EnrollDate", "GraduateDate" },
                values: new object[] { new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 2,
                columns: new[] { "Birthday", "EnrollDate", "GraduateDate" },
                values: new object[] { new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 3,
                columns: new[] { "Birthday", "EnrollDate", "GraduateDate" },
                values: new object[] { new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
