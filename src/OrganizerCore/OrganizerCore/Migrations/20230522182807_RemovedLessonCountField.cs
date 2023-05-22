using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganizerCore.Migrations
{
    /// <inheritdoc />
    public partial class RemovedLessonCountField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LessonsCount",
                table: "IndividualCourses");

            migrationBuilder.DropColumn(
                name: "LessonsCount",
                table: "GroupCourses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LessonsCount",
                table: "IndividualCourses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LessonsCount",
                table: "GroupCourses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
