namespace TrajnohuAPI.Data.Models.FitnessPlanModels
{
    public class TrainingDay
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        //Navigation Properties
        public int FitnessPlanId { get; set; }
        public FitnessPlan? FitnessPlan { get; set; }
        public ICollection<TrainingDay_Exercise>? TrainingDay_Exercises { get; set; }
    }
}
