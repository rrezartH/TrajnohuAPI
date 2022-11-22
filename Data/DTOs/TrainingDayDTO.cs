namespace TrajnohuAPI.Data.DTOs
{
    public class TrainingDayDTO
    {
        public string Name { get; set; } = null!;
        public ICollection<GetExerciseDTO>? Exercises { get; set; }

    }
}
