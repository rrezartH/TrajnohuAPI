using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrajnohuAPI.Migrations
{
    /// <inheritdoc />
    public partial class LinkedTrainingDayWithFitnessPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FitnessPlan_TrainingDays");

            migrationBuilder.AddColumn<int>(
                name: "FitnessPlanId",
                table: "TrainingDays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDays_FitnessPlanId",
                table: "TrainingDays",
                column: "FitnessPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingDays_FitnessPlans_FitnessPlanId",
                table: "TrainingDays",
                column: "FitnessPlanId",
                principalTable: "FitnessPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingDays_FitnessPlans_FitnessPlanId",
                table: "TrainingDays");

            migrationBuilder.DropIndex(
                name: "IX_TrainingDays_FitnessPlanId",
                table: "TrainingDays");

            migrationBuilder.DropColumn(
                name: "FitnessPlanId",
                table: "TrainingDays");

            migrationBuilder.CreateTable(
                name: "FitnessPlan_TrainingDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FitnessPlanId = table.Column<int>(type: "int", nullable: false),
                    TrainingDayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessPlan_TrainingDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FitnessPlan_TrainingDays_FitnessPlans_FitnessPlanId",
                        column: x => x.FitnessPlanId,
                        principalTable: "FitnessPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FitnessPlan_TrainingDays_TrainingDays_TrainingDayId",
                        column: x => x.TrainingDayId,
                        principalTable: "TrainingDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FitnessPlan_TrainingDays_FitnessPlanId",
                table: "FitnessPlan_TrainingDays",
                column: "FitnessPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessPlan_TrainingDays_TrainingDayId",
                table: "FitnessPlan_TrainingDays",
                column: "TrainingDayId");
        }
    }
}
