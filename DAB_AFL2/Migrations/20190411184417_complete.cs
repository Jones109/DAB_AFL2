using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAB_AFL2.Migrations
{
    public partial class complete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calendars",
                columns: table => new
                {
                    CalendarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CalendarName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendars", x => x.CalendarId);
                });

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
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    CalendarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Calendars_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendars",
                        principalColumn: "CalendarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    AssignmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Attempt = table.Column<int>(nullable: false),
                    CourseID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.AssignmentID);
                    table.ForeignKey(
                        name: "FK_Assignments_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    FolderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    Course_FK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.FolderId);
                    table.ForeignKey(
                        name: "FK_Folders_Courses_Course_FK",
                        column: x => x.Course_FK,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Folders_Folders_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Folders",
                        principalColumn: "FolderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enrolled",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    Grade = table.Column<int>(nullable: false),
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
                        name: "FK_Groups_Assignments_AssignmentID",
                        column: x => x.AssignmentID,
                        principalTable: "Assignments",
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
                name: "Areas",
                columns: table => new
                {
                    AreaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentUri = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    FolderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.AreaId);
                    table.ForeignKey(
                        name: "FK_Areas_Folders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "Folders",
                        principalColumn: "FolderId",
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
                    { 3, "Course3" },
                    { 4, "Course4" },
                    { 5, "Course5" },
                    { 6, "Course6" },
                    { 7, "Course7" },
                    { 8, "Course8" },
                    { 9, "Course9" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "Birthday", "EnrollDate", "GraduateDate", "Name" },
                values: new object[,]
                {
                    { 15, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), "Student15" },
                    { 14, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), "Student14" },
                    { 13, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), "Student13" },
                    { 12, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), "Student12" },
                    { 11, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), "Student11" },
                    { 10, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), "Student10" },
                    { 9, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), "Student9" },
                    { 7, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), "Student7" },
                    { 6, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), "Student6" },
                    { 5, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), "Student5" },
                    { 4, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), "Student4" },
                    { 3, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), "Student3" },
                    { 2, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), "Student2" },
                    { 1, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), "Student1" },
                    { 8, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), "Student8" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherId", "Birthday", "Name" },
                values: new object[,]
                {
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teacher7" },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teacher1" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teacher2" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teacher3" },
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
                    { 1, 0, 1, null },
                    { 2, 0, 2, null },
                    { 6, 0, 6, null },
                    { 5, 0, 5, null },
                    { 4, 0, 4, null },
                    { 3, 0, 3, null }
                });

            migrationBuilder.InsertData(
                table: "Enrolled",
                columns: new[] { "CourseId", "StudentId", "Grade", "Status" },
                values: new object[,]
                {
                    { 1, 5, 0, "Active" },
                    { 2, 6, 0, "Active" },
                    { 3, 7, 0, "Active" },
                    { 4, 8, 0, "Active" },
                    { 6, 10, 0, "Active" },
                    { 8, 4, 0, "Active" },
                    { 7, 11, 0, "Active" },
                    { 8, 12, 0, "Active" },
                    { 9, 13, 0, "Active" },
                    { 1, 14, 0, "Active" },
                    { 2, 15, 0, "Active" },
                    { 3, 15, 0, "Active" },
                    { 5, 9, 0, "Active" },
                    { 7, 4, 0, "Active" },
                    { 9, 5, 0, "Active" },
                    { 5, 3, 0, "Active" },
                    { 4, 2, 0, "Active" },
                    { 3, 2, 0, "Active" },
                    { 2, 1, 0, "Active" },
                    { 1, 1, 0, "Active" },
                    { 6, 3, 0, "Active" }
                });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "FolderId", "Course_FK", "Name", "ParentId" },
                values: new object[,]
                {
                    { 1, 1, "Folder1", null },
                    { 3, 1, "Folder3", null },
                    { 4, 2, "Folder4", null },
                    { 5, 2, "Folder5", null },
                    { 2, 1, "Folder2", null },
                    { 7, 3, "Folder7", null },
                    { 8, 3, "Folder8", null },
                    { 9, 3, "Folder9", null },
                    { 6, 2, "Folder6", null }
                });

            migrationBuilder.InsertData(
                table: "TeacherCourses",
                columns: new[] { "TeacherID", "CourseID" },
                values: new object[,]
                {
                    { 7, 7 },
                    { 1, 1 },
                    { 1, 9 },
                    { 2, 2 },
                    { 2, 5 },
                    { 3, 3 },
                    { 3, 7 },
                    { 4, 4 },
                    { 4, 9 },
                    { 5, 5 },
                    { 6, 6 },
                    { 8, 8 }
                });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "AreaId", "ContentUri", "FolderId", "Name" },
                values: new object[,]
                {
                    { 4, "Content4", 4, "Area4" },
                    { 13, "Content13", 5, "Area13" },
                    { 5, "Content5", 5, "Area5" },
                    { 12, "Content12", 4, "Area12" },
                    { 11, "Content11", 3, "Area11" },
                    { 10, "Content10", 2, "Area10" },
                    { 2, "Content2", 2, "Area2" },
                    { 3, "Content3", 3, "Area3" },
                    { 9, "Content9", 1, "Area9" },
                    { 8, "Content8", 1, "Area8" },
                    { 1, "Content1", 1, "Area1" }
                });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "FolderId", "Course_FK", "Name", "ParentId" },
                values: new object[] { 10, 1, "Folder10", 1 });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "AssignmentID", "Grade", "GroupSize", "TeacherId" },
                values: new object[,]
                {
                    { 4, 4, 0, 4, 4 },
                    { 11, 5, 4, 3, 5 },
                    { 5, 5, 7, 3, 5 },
                    { 16, 4, 0, 4, 2 },
                    { 10, 4, 0, 4, 4 },
                    { 17, 5, 12, 3, 3 },
                    { 6, 6, 0, 2, 6 },
                    { 15, 3, 10, 2, 1 },
                    { 1, 1, 0, 4, 1 },
                    { 3, 3, 4, 2, 3 },
                    { 12, 6, 0, 2, 6 },
                    { 14, 2, 0, 3, 8 },
                    { 8, 2, 0, 3, 2 },
                    { 2, 2, 7, 3, 2 },
                    { 13, 1, 4, 4, 7 },
                    { 7, 1, 4, 4, 1 },
                    { 9, 3, 7, 2, 3 },
                    { 18, 6, 0, 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "AreaId", "ContentUri", "FolderId", "Name" },
                values: new object[,]
                {
                    { 6, "Content6", 10, "Area6" },
                    { 7, "Content7", 10, "Area7" }
                });

            migrationBuilder.InsertData(
                table: "GroupStudents",
                columns: new[] { "GroupId", "StudentId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 11, 3 },
                    { 5, 11 },
                    { 10, 1 },
                    { 4, 10 },
                    { 9, 15 },
                    { 3, 9 },
                    { 3, 8 },
                    { 8, 14 },
                    { 6, 12 },
                    { 2, 6 },
                    { 2, 5 },
                    { 2, 4 },
                    { 7, 13 },
                    { 1, 3 },
                    { 1, 2 },
                    { 3, 7 },
                    { 12, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_FolderId",
                table: "Areas",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CourseID",
                table: "Assignments",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolled_StudentId",
                table: "Enrolled",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CalendarId",
                table: "Events",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_Course_FK",
                table: "Folders",
                column: "Course_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_ParentId",
                table: "Folders",
                column: "ParentId");

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
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Enrolled");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "GroupStudents");

            migrationBuilder.DropTable(
                name: "TeacherCourses");

            migrationBuilder.DropTable(
                name: "Folders");

            migrationBuilder.DropTable(
                name: "Calendars");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
