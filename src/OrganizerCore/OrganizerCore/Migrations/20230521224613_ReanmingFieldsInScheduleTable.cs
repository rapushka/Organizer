using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganizerCore.Migrations
{
    /// <inheritdoc />
    public partial class ReanmingFieldsInScheduleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_GroupCourses_GroupCoursesOfStudentId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_IndividualCourses_IndividualCoursesOfStudentId",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "IndividualCoursesOfStudentId",
                table: "Schedules",
                newName: "IndividualCourseId");

            migrationBuilder.RenameColumn(
                name: "GroupCoursesOfStudentId",
                table: "Schedules",
                newName: "GroupCourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_IndividualCoursesOfStudentId",
                table: "Schedules",
                newName: "IX_Schedules_IndividualCourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_GroupCoursesOfStudentId",
                table: "Schedules",
                newName: "IX_Schedules_GroupCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_GroupCourses_GroupCourseId",
                table: "Schedules",
                column: "GroupCourseId",
                principalTable: "GroupCourses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_IndividualCourses_IndividualCourseId",
                table: "Schedules",
                column: "IndividualCourseId",
                principalTable: "IndividualCourses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_GroupCourses_GroupCourseId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_IndividualCourses_IndividualCourseId",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "IndividualCourseId",
                table: "Schedules",
                newName: "IndividualCoursesOfStudentId");

            migrationBuilder.RenameColumn(
                name: "GroupCourseId",
                table: "Schedules",
                newName: "GroupCoursesOfStudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_IndividualCourseId",
                table: "Schedules",
                newName: "IX_Schedules_IndividualCoursesOfStudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_GroupCourseId",
                table: "Schedules",
                newName: "IX_Schedules_GroupCoursesOfStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_GroupCourses_GroupCoursesOfStudentId",
                table: "Schedules",
                column: "GroupCoursesOfStudentId",
                principalTable: "GroupCourses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_IndividualCourses_IndividualCoursesOfStudentId",
                table: "Schedules",
                column: "IndividualCoursesOfStudentId",
                principalTable: "IndividualCourses",
                principalColumn: "Id");
        }
    }
}
