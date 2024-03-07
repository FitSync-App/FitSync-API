using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutApp.Migrations
{
    /// <inheritdoc />
    public partial class _5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Muscle_Muscle_MuscleId",
                table: "Exercise_Muscle");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_Muscle_MuscleId",
                table: "Exercise_Muscle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Exercise_Muscle_MuscleId",
                table: "Exercise_Muscle",
                column: "MuscleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Muscle_Muscle_MuscleId",
                table: "Exercise_Muscle",
                column: "MuscleId",
                principalTable: "Muscle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
