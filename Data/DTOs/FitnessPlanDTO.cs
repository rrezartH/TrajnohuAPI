namespace TrajnohuAPI.Data.DTOs
{
    public class GetFitnessPlanDTO
    {
        public string Name { get; set; } = null!;
        public int UserId { get; set; }
        public ICollection<TrainingDayDTO>? TrainingDays { get; set; }
    }
}
