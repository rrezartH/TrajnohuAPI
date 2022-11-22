using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrajnohuAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangedTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingDay_Exercises_FitnessExercises_FitnessExerciseId",
                table: "TrainingDay_Exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessExercises",
                table: "FitnessExercises");

            migrationBuilder.RenameTable(
                name: "FitnessExercises",
                newName: "Exercises");

            migrationBuilder.RenameColumn(
                name: "isHomeExerciseToo",
                table: "Exercises",
                newName: "IsHomeExercise");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingDay_Exercises_Exercises_FitnessExerciseId",
                table: "TrainingDay_Exercises",
                column: "FitnessExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingDay_Exercises_Exercises_FitnessExerciseId",
                table: "TrainingDay_Exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises");

            migrationBuilder.RenameTable(
                name: "Exercises",
                newName: "FitnessExercises");

            migrationBuilder.RenameColumn(
                name: "IsHomeExercise",
                table: "FitnessExercises",
                newName: "isHomeExerciseToo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessExercises",
                table: "FitnessExercises",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingDay_Exercises_FitnessExercises_FitnessExerciseId",
                table: "TrainingDay_Exercises",
                column: "FitnessExerciseId",
                principalTable: "FitnessExercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
