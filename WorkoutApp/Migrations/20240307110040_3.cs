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
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Exercise_ExerciseId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Muscle_Exercise_ExerciseId",
                table: "Muscle");

            migrationBuilder.DropIndex(
                name: "IX_Muscle_ExerciseId",
                table: "Muscle");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_ExerciseId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "Muscle");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "Equipment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "Muscle",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "Equipment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Muscle_ExerciseId",
                table: "Muscle",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_ExerciseId",
                table: "Equipment",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Exercise_ExerciseId",
                table: "Equipment",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Muscle_Exercise_ExerciseId",
                table: "Muscle",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id");
        }
    }
}
