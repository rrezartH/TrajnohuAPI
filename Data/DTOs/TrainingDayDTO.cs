namespace TrajnohuAPI.Data.DTOs
{
    public class GetTrainingDayDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<GetExerciseDTO>? Exercises { get; set; }
    }

    public class AddTrainingDayDTO
    {
        public string Name { get; set; } = null!;
        public ICollection<int>? ExerciseIds { get; set; }
    }

    public class UpdateTrainingDayDTO
    {
        public string? Name { get; set; }
        public ICollection<int>? ExerciseIds { get; set; }
    }
}
