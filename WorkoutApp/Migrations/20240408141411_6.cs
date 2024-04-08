using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitsync.Migrations
{
    /// <inheritdoc />
    public partial class _6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Workout_UserId",
                table: "Workout",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workout_User_UserId",
                table: "Workout",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workout_User_UserId",
                table: "Workout");

            migrationBuilder.DropIndex(
                name: "IX_Workout_UserId",
                table: "Workout");
        }
    }
}
