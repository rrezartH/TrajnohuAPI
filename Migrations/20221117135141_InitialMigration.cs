using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrajnohuAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FitnessExercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BodyTarget = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BodyPart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Equipment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GifURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessExercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FitnessPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessPlans", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "FitnessExercise_TrainingDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FitnessExerciseId = table.Column<int>(type: "int", nullable: false),
                    TrainingDayId = table.Column<int>(type: "int", nullable: false),
                    FitnessPlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessExercise_TrainingDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FitnessExercise_TrainingDays_FitnessExercises_FitnessExerciseId",
                        column: x => x.FitnessExerciseId,
                        principalTable: "FitnessExercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FitnessExercise_TrainingDays_FitnessPlans_FitnessPlanId",
                        column: x => x.FitnessPlanId,
                        principalTable: "FitnessPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FitnessExercise_TrainingDays_TrainingDays_TrainingDayId",
                        column: x => x.TrainingDayId,
                        principalTable: "TrainingDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FitnessExercise_TrainingDays_FitnessExerciseId",
                table: "FitnessExercise_TrainingDays",
                column: "FitnessExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessExercise_TrainingDays_FitnessPlanId",
                table: "FitnessExercise_TrainingDays",
                column: "FitnessPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessExercise_TrainingDays_TrainingDayId",
                table: "FitnessExercise_TrainingDays",
                column: "TrainingDayId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FitnessExercise_TrainingDays");

            migrationBuilder.DropTable(
                name: "FitnessExercises");

            migrationBuilder.DropTable(
                name: "FitnessPlans");

            migrationBuilder.DropTable(
                name: "TrainingDays");
        }
    }
}
