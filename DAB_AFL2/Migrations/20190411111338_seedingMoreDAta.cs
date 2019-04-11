using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAB_AFL2.Migrations
{
    public partial class seedingMoreDAta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Enrolled",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Enrolled",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "GroupStudents",
                keyColumns: new[] { "GroupId", "StudentId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "GroupStudents",
                keyColumns: new[] { "GroupId", "StudentId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName" },
                values: new object[,]
                {
                    { 4, "Course4" },
                    { 5, "Course5" },
                    { 6, "Course6" },
                    { 7, "Course7" },
                    { 8, "Course8" },
                    { 9, "Course9" }
                });

            migrationBuilder.InsertData(
                table: "Enrolled",
                columns: new[] { "CourseId", "StudentId", "Grade", "Status" },
                values: new object[,]
                {
                    { 2, 1, 0, "Active" },
                    { 3, 2, 0, "Active" }
                });

            migrationBuilder.InsertData(
                table: "GroupStudents",
                columns: new[] { "GroupId", "StudentId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 1, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 2,
                column: "Grade",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 3,
                column: "Grade",
                value: 4);

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "AssignmentID", "Grade", "GroupSize", "TeacherId" },
                values: new object[,]
                {
                    { 15, 3, 10, 2, 1 },
                    { 7, 1, 4, 4, 1 },
                    { 8, 2, 0, 3, 2 },
                    { 9, 3, 7, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "Birthday", "EnrollDate", "GraduateDate", "Name" },
                values: new object[,]
                {
                    { 11, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), "Student11" },
                    { 15, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), "Student15" },
                    { 14, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), "Student14" },
                    { 13, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), "Student13" },
                    { 12, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), "Student12" },
                    { 10, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), "Student10" },
                    { 4, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), "Student4" },
                    { 8, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), "Student8" },
                    { 7, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), "Student7" },
                    { 6, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), "Student6" },
                    { 5, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), "Student5" },
                    { 9, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), "Student9" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherId", "Birthday", "Name" },
                values: new object[,]
                {
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teacher7" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teacher4" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teacher5" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teacher6" },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teacher8" }
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "AssignmentID", "Attempt", "CourseID", "Description" },
                values: new object[,]
                {
                    { 4, 0, 4, null },
                    { 5, 0, 5, null },
                    { 6, 0, 6, null }
                });

            migrationBuilder.InsertData(
                table: "Enrolled",
                columns: new[] { "CourseId", "StudentId", "Grade", "Status" },
                values: new object[,]
                {
                    { 5, 9, 0, "Active" },
                    { 8, 12, 0, "Active" },
                    { 4, 8, 0, "Active" },
                    { 9, 13, 0, "Active" },
                    { 3, 7, 0, "Active" },
                    { 2, 6, 0, "Active" },
                    { 1, 14, 0, "Active" },
                    { 1, 5, 0, "Active" },
                    { 9, 5, 0, "Active" },
                    { 6, 10, 0, "Active" },
                    { 8, 4, 0, "Active" },
                    { 7, 4, 0, "Active" },
                    { 2, 15, 0, "Active" },
                    { 3, 15, 0, "Active" },
                    { 6, 3, 0, "Active" },
                    { 5, 3, 0, "Active" },
                    { 4, 2, 0, "Active" },
                    { 7, 11, 0, "Active" }
                });

            migrationBuilder.InsertData(
                table: "GroupStudents",
                columns: new[] { "GroupId", "StudentId" },
                values: new object[,]
                {
                    { 7, 13 },
                    { 9, 15 },
                    { 8, 14 },
                    { 3, 8 },
                    { 3, 7 },
                    { 2, 6 },
                    { 2, 5 },
                    { 2, 4 },
                    { 3, 9 }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "AssignmentID", "Grade", "GroupSize", "TeacherId" },
                values: new object[,]
                {
                    { 14, 2, 0, 3, 8 },
                    { 13, 1, 4, 4, 7 }
                });

            migrationBuilder.InsertData(
                table: "TeacherCourses",
                columns: new[] { "TeacherID", "CourseID" },
                values: new object[,]
                {
                    { 1, 9 },
                    { 3, 7 },
                    { 2, 5 },
                    { 4, 4 },
                    { 4, 9 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "AssignmentID", "Grade", "GroupSize", "TeacherId" },
                values: new object[,]
                {
                    { 4, 4, 0, 4, 4 },
                    { 10, 4, 0, 4, 4 },
                    { 16, 4, 0, 4, 2 },
                    { 5, 5, 7, 3, 5 },
                    { 11, 5, 4, 3, 5 },
                    { 17, 5, 12, 3, 3 },
                    { 6, 6, 0, 2, 6 },
                    { 12, 6, 0, 2, 6 },
                    { 18, 6, 0, 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "GroupStudents",
                columns: new[] { "GroupId", "StudentId" },
                values: new object[,]
                {
                    { 4, 10 },
                    { 10, 1 },
                    { 5, 11 },
                    { 11, 3 },
                    { 6, 12 },
                    { 12, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Enrolled",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "Enrolled",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, 14 });

            migrationBuilder.DeleteData(
                table: "Enrolled",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Enrolled",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "Enrolled",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, 15 });

            migrationBuilder.DeleteData(
                table: "Enrolled",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Enrolled",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "Enrolled",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 3, 15 });

            migrationBuilder.DeleteData(
                table: "Enrolled",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "Enrolled",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "Enrolled",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "Enrolled",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "Enrolled",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "Enrolled",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 6, 10 });

            migrationBuilder.DeleteData(
                table: "Enrolled",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "Enrolled",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 7, 11 });

            migrationBuilder.DeleteData(
                table: "Enrolled",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.DeleteData(
                table: "Enrolled",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 8, 12 });

            migrationBuilder.DeleteData(
                table: "Enrolled",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 9, 5 });

            migrationBuilder.DeleteData(
                table: "Enrolled",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 9, 13 });

            migrationBuilder.DeleteData(
                table: "GroupStudents",
                keyColumns: new[] { "GroupId", "StudentId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "GroupStudents",
                keyColumns: new[] { "GroupId", "StudentId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "GroupStudents",
                keyColumns: new[] { "GroupId", "StudentId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "GroupStudents",
                keyColumns: new[] { "GroupId", "StudentId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "GroupStudents",
                keyColumns: new[] { "GroupId", "StudentId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "GroupStudents",
                keyColumns: new[] { "GroupId", "StudentId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "GroupStudents",
                keyColumns: new[] { "GroupId", "StudentId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "GroupStudents",
                keyColumns: new[] { "GroupId", "StudentId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "GroupStudents",
                keyColumns: new[] { "GroupId", "StudentId" },
                keyValues: new object[] { 4, 10 });

            migrationBuilder.DeleteData(
                table: "GroupStudents",
                keyColumns: new[] { "GroupId", "StudentId" },
                keyValues: new object[] { 5, 11 });

            migrationBuilder.DeleteData(
                table: "GroupStudents",
                keyColumns: new[] { "GroupId", "StudentId" },
                keyValues: new object[] { 6, 12 });

            migrationBuilder.DeleteData(
                table: "GroupStudents",
                keyColumns: new[] { "GroupId", "StudentId" },
                keyValues: new object[] { 7, 13 });

            migrationBuilder.DeleteData(
                table: "GroupStudents",
                keyColumns: new[] { "GroupId", "StudentId" },
                keyValues: new object[] { 8, 14 });

            migrationBuilder.DeleteData(
                table: "GroupStudents",
                keyColumns: new[] { "GroupId", "StudentId" },
                keyValues: new object[] { 9, 15 });

            migrationBuilder.DeleteData(
                table: "GroupStudents",
                keyColumns: new[] { "GroupId", "StudentId" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "GroupStudents",
                keyColumns: new[] { "GroupId", "StudentId" },
                keyValues: new object[] { 11, 3 });

            migrationBuilder.DeleteData(
                table: "GroupStudents",
                keyColumns: new[] { "GroupId", "StudentId" },
                keyValues: new object[] { 12, 2 });

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TeacherCourses",
                keyColumns: new[] { "TeacherID", "CourseID" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "TeacherCourses",
                keyColumns: new[] { "TeacherID", "CourseID" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "TeacherCourses",
                keyColumns: new[] { "TeacherID", "CourseID" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "TeacherCourses",
                keyColumns: new[] { "TeacherID", "CourseID" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "TeacherCourses",
                keyColumns: new[] { "TeacherID", "CourseID" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "TeacherCourses",
                keyColumns: new[] { "TeacherID", "CourseID" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "TeacherCourses",
                keyColumns: new[] { "TeacherID", "CourseID" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "TeacherCourses",
                keyColumns: new[] { "TeacherID", "CourseID" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                table: "TeacherCourses",
                keyColumns: new[] { "TeacherID", "CourseID" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "AssignmentID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "AssignmentID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "AssignmentID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "Enrolled",
                columns: new[] { "CourseId", "StudentId", "Grade", "Status" },
                values: new object[,]
                {
                    { 2, 2, 0, "Active" },
                    { 3, 3, 0, "Active" }
                });

            migrationBuilder.InsertData(
                table: "GroupStudents",
                columns: new[] { "GroupId", "StudentId" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 2,
                column: "Grade",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 3,
                column: "Grade",
                value: 0);
        }
    }
}
