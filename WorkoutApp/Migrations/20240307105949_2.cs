using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutApp.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Exercise",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MuscleId",
                table: "Exercise",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_EquipmentId",
                table: "Exercise",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_MuscleId",
                table: "Exercise",
                column: "MuscleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Equipment_EquipmentId",
                table: "Exercise",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Muscle_MuscleId",
                table: "Exercise",
                column: "MuscleId",
                principalTable: "Muscle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Equipment_EquipmentId",
                table: "Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Muscle_MuscleId",
                table: "Exercise");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_EquipmentId",
                table: "Exercise");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_MuscleId",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "MuscleId",
                table: "Exercise");
        }
    }
}
