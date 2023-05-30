using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganizerCore.Migrations
{
    /// <inheritdoc />
    public partial class AddIsGroupFieldToSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsGroup",
                table: "Schedules",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsGroup",
                table: "Schedules");
        }
    }
}
