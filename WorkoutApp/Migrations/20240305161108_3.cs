using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutApp.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Workout_Exercise_ExerciseId",
                table: "Workout_Exercise",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Workout_Exercise_WorkoutId",
                table: "Workout_Exercise",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workout_Exercise_Exercise_ExerciseId",
                table: "Workout_Exercise",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workout_Exercise_Workout_WorkoutId",
                table: "Workout_Exercise",
                column: "WorkoutId",
                principalTable: "Workout",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workout_Exercise_Exercise_ExerciseId",
                table: "Workout_Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_Workout_Exercise_Workout_WorkoutId",
                table: "Workout_Exercise");

            migrationBuilder.DropIndex(
                name: "IX_Workout_Exercise_ExerciseId",
                table: "Workout_Exercise");

            migrationBuilder.DropIndex(
                name: "IX_Workout_Exercise_WorkoutId",
                table: "Workout_Exercise");
        }
    }
}
