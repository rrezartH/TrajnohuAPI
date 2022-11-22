namespace TrajnohuAPI.Data.Models.FitnessPlanModels
{
    public class FitnessPlan
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        //Navigation Properties
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public ICollection<TrainingDay>? TrainingDays { get; set; }
    }
}
