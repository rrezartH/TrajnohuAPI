namespace TrajnohuAPI.Data.DTOs
{
    public class GetFitnessPlanDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int UserId { get; set; }
        public ICollection<GetTrainingDayDTO>? TrainingDays { get; set; }
    }

    public class AddFitnessPlanDTO
    {
        public string Name { get; set; } = null!;
        public int UserId { get; set; }
        public ICollection<AddTrainingDTO>? TrainingDays { get; set;}
    }
}
