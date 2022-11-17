namespace TrajnohuAPI.Data.Models.FitnessPlanModels
{
    public class FitnessExercise
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string BodyTarget { get; set; } = null!;
        public string BodyPart { get; set; } = null!;
        public string Equipment { get; set; } = "Peshe Trupore";
        public string? GifURL { get; set; }

        //Navigation Properties
        public ICollection<FitnessPlan_FitnessExercise>? FitnessExercise_TrainingDay { get; set; }
    }
}
