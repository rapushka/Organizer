using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganizerCore.Migrations
{
    /// <inheritdoc />
    public partial class RemovedLessonsCountFromCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LessonsCount",
                table: "Courses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LessonsCount",
                table: "Courses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
