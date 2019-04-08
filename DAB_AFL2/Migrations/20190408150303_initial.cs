using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAB_AFL2.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseName = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EnrollDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    GraduateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    AssignmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Attempt = table.Column<int>(nullable: false),
                    CourseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => x.AssignmentID);
                    table.ForeignKey(
                        name: "FK_Assignment_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrolled",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrolled", x => new { x.CourseId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_Enrolled_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrolled_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherCourses",
                columns: table => new
                {
                    TeacherID = table.Column<int>(nullable: false),
                    CourseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCourses", x => new { x.TeacherID, x.CourseID });
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Teachers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Grade = table.Column<int>(nullable: false),
                    GroupSize = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false),
                    AssignmentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_Groups_Assignment_AssignmentID",
                        column: x => x.AssignmentID,
                        principalTable: "Assignment",
                        principalColumn: "AssignmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Groups_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupStudents",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupStudents", x => new { x.GroupId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_GroupStudents_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName" },
                values: new object[,]
                {
                    { 1, "Course1" },
                    { 2, "Course2" },
                    { 3, "Course3" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "Birthday", "EnrollDate", "GraduateDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Local), "Student1" },
                    { 2, new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Local), "Student2" },
                    { 3, new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Local), "Student3" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherId", "Birthday", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teacher1" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teacher2" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teacher3" }
                });

            migrationBuilder.InsertData(
                table: "Assignment",
                columns: new[] { "AssignmentID", "Attempt", "CourseID" },
                values: new object[,]
                {
                    { 1, 0, 1 },
                    { 2, 0, 2 },
                    { 3, 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "Enrolled",
                columns: new[] { "CourseId", "StudentId", "Status" },
                values: new object[,]
                {
                    { 1, 1, "Active" },
                    { 2, 2, "Active" },
                    { 3, 3, "Active" }
                });

            migrationBuilder.InsertData(
                table: "TeacherCourses",
                columns: new[] { "TeacherID", "CourseID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "AssignmentID", "Grade", "GroupSize", "TeacherId" },
                values: new object[] { 1, 1, 0, 4, 1 });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "AssignmentID", "Grade", "GroupSize", "TeacherId" },
                values: new object[] { 2, 2, 0, 3, 2 });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "AssignmentID", "Grade", "GroupSize", "TeacherId" },
                values: new object[] { 3, 3, 0, 2, 3 });

            migrationBuilder.InsertData(
                table: "GroupStudents",
                columns: new[] { "GroupId", "StudentId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "GroupStudents",
                columns: new[] { "GroupId", "StudentId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "GroupStudents",
                columns: new[] { "GroupId", "StudentId" },
                values: new object[] { 3, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_CourseID",
                table: "Assignment",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolled_StudentId",
                table: "Enrolled",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_AssignmentID",
                table: "Groups",
                column: "AssignmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_TeacherId",
                table: "Groups",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupStudents_StudentId",
                table: "GroupStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_CourseID",
                table: "TeacherCourses",
                column: "CourseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrolled");

            migrationBuilder.DropTable(
                name: "GroupStudents");

            migrationBuilder.DropTable(
                name: "TeacherCourses");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Assignment");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
