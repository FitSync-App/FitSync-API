using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitsync.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Days",
                table: "Workout_Exercise");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Days",
                table: "Workout_Exercise",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
