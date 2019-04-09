using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAB_AFL2.Migrations
{
    public partial class CourseContent1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Calendars",
                keyColumn: "CalendarId",
                keyValue: 1);

            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    FolderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Parent = table.Column<string>(nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    AreaId = table.Column<int>(nullable: false),
                    ContentUri = table.Column<string>(nullable: true),
                    MainArea = table.Column<string>(nullable: true),
                    Parent = table.Column<string>(nullable: true),
                    FolderId_FK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.AreaId);
                    table.ForeignKey(
                        name: "FK_Areas_Folders_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Folders",
                        principalColumn: "FolderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "FolderId", "Course_FK", "Name", "Parent" },
                values: new object[,]
                {
                    { 1, 1, "Folder1", null },
                    { 2, 1, "Folder2", null },
                    { 3, 1, "Folder3", null },
                    { 4, 2, "Folder4", null },
                    { 5, 2, "Folder5", null },
                    { 6, 2, "Folder6", null },
                    { 7, 3, "Folder7", null },
                    { 8, 3, "Folder8", null },
                    { 9, 3, "Folder9", null }
                });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "AreaId", "ContentUri", "FolderId_FK", "MainArea", "Parent" },
                values: new object[] { 1, "SupBro", 0, "MainDataWithBigFont", null });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "AreaId", "ContentUri", "FolderId_FK", "MainArea", "Parent" },
                values: new object[] { 2, "SupHo", 0, "SubDataWithSmallerFont", "MainDataWithBigFont" });

            migrationBuilder.CreateIndex(
                name: "IX_Folders_Course_FK",
                table: "Folders",
                column: "Course_FK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Folders");

            migrationBuilder.InsertData(
                table: "Calendars",
                column: "CalendarId",
                value: 1);
        }
    }
}
