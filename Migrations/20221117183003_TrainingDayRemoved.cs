using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrajnohuAPI.Migrations
{
    /// <inheritdoc />
    public partial class TrainingDayRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessExercise_TrainingDays_TrainingDays_TrainingDayId",
                table: "FitnessExercise_TrainingDays");

            migrationBuilder.DropTable(
                name: "TrainingDays");

            migrationBuilder.DropIndex(
                name: "IX_FitnessExercise_TrainingDays_TrainingDayId",
                table: "FitnessExercise_TrainingDays");

            migrationBuilder.DropColumn(
                name: "TrainingDayId",
                table: "FitnessExercise_TrainingDays");

            migrationBuilder.AddColumn<string>(
                name: "Day",
                table: "FitnessExercise_TrainingDays",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "FitnessExercise_TrainingDays");

            migrationBuilder.AddColumn<int>(
                name: "TrainingDayId",
                table: "FitnessExercise_TrainingDays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TrainingDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingDays", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FitnessExercise_TrainingDays_TrainingDayId",
                table: "FitnessExercise_TrainingDays",
                column: "TrainingDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessExercise_TrainingDays_TrainingDays_TrainingDayId",
                table: "FitnessExercise_TrainingDays",
                column: "TrainingDayId",
                principalTable: "TrainingDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
