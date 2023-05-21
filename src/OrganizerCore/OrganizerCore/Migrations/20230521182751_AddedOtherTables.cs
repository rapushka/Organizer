using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganizerCore.Migrations
{
    /// <inheritdoc />
    public partial class AddedOtherTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    BeginningDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndingDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MinAge = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxAge = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxStudentsInGroupCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndividualCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    BeginningDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndingDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Indicator = table.Column<string>(type: "TEXT", nullable: false),
                    LessonsCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndividualCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    GroupId = table.Column<int>(type: "INTEGER", nullable: false),
                    Indicator = table.Column<string>(type: "TEXT", nullable: false),
                    LessonsCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupCourses_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IndividualCoursesOfStudentId = table.Column<int>(type: "INTEGER", nullable: true),
                    GroupCoursesOfStudentId = table.Column<int>(type: "INTEGER", nullable: true),
                    ScheduledTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Note = table.Column<string>(type: "TEXT", nullable: false),
                    IsHeld = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_GroupCourses_GroupCoursesOfStudentId",
                        column: x => x.GroupCoursesOfStudentId,
                        principalTable: "GroupCourses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Schedules_IndividualCourses_IndividualCoursesOfStudentId",
                        column: x => x.IndividualCoursesOfStudentId,
                        principalTable: "IndividualCourses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupCourses_GroupId",
                table: "GroupCourses",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupCourses_StudentId",
                table: "GroupCourses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CourseId",
                table: "Groups",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCourses_CourseId",
                table: "IndividualCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCourses_StudentId",
                table: "IndividualCourses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_GroupCoursesOfStudentId",
                table: "Schedules",
                column: "GroupCoursesOfStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_IndividualCoursesOfStudentId",
                table: "Schedules",
                column: "IndividualCoursesOfStudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "GroupCourses");

            migrationBuilder.DropTable(
                name: "IndividualCourses");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
