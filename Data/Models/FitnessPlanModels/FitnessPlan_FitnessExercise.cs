namespace TrajnohuAPI.Data.Models.FitnessPlanModels
{
    public class FitnessPlan_FitnessExercise
    {
        public int Id { get; set; }
        public string Day { get; set; } = null!;
        public int FitnessExerciseId { get; set; }
        public FitnessExercise FitnessExercise { get; set; } = null!;
        public int FitnessPlanId { get; set; }
        public FitnessPlan FitnessPlan { get; set; } = null!;
    }
}
