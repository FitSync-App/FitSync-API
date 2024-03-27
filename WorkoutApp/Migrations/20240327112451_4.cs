using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitsync.Migrations
{
    /// <inheritdoc />
    public partial class _4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workout_Exercise_Exercise_ExerciseId",
                table: "Workout_Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_Workout_Exercise_Workout_WorkoutId",
                table: "Workout_Exercise");

            migrationBuilder.AlterColumn<int>(
                name: "WorkoutId",
                table: "Workout_Exercise",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "Workout_Exercise",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "WorkoutId",
                table: "Workout_Exercise",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "Workout_Exercise",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Workout_Exercise_Exercise_ExerciseId",
                table: "Workout_Exercise",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Workout_Exercise_Workout_WorkoutId",
                table: "Workout_Exercise",
                column: "WorkoutId",
                principalTable: "Workout",
                principalColumn: "Id");
        }
    }
}
