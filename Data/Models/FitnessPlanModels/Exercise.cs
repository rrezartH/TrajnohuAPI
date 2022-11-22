namespace TrajnohuAPI.Data.Models.FitnessPlanModels
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string BodyTarget { get; set; } = null!;
        public string BodyPart { get; set; } = null!;
        public string Equipment { get; set; } = "Peshe Trupore";
        public string? GifURL { get; set; }
        public bool IsHomeExercise { get; set; }

        //Navigation Properties
        public ICollection<TrainingDay_Exercise>? TrainingDay_Exercises { get; set; }
    }
}
