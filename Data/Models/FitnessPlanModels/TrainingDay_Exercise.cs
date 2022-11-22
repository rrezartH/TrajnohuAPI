namespace TrajnohuAPI.Data.Models.FitnessPlanModels
{
    public class TrainingDay_Exercise
    {
        public int Id { get; set; }
        public int TrainingDayId { get; set; }
        public TrainingDay TrainingDay { get; set; } = null!;
        public int FitnessExerciseId { get; set; }
        public Exercise FitnessExercise { get; set; } = null!;
    }
}
