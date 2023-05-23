using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganizerCore.Migrations
{
    /// <inheritdoc />
    public partial class GroupInsteadOfGroupCourses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_GroupCourses_GroupCourseId",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "GroupCourseId",
                table: "Schedules",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_GroupCourseId",
                table: "Schedules",
                newName: "IX_Schedules_GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Groups_GroupId",
                table: "Schedules",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Groups_GroupId",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Schedules",
                newName: "GroupCourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_GroupId",
                table: "Schedules",
                newName: "IX_Schedules_GroupCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_GroupCourses_GroupCourseId",
                table: "Schedules",
                column: "GroupCourseId",
                principalTable: "GroupCourses",
                principalColumn: "Id");
        }
    }
}
