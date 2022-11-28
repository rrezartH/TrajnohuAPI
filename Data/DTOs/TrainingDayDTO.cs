namespace TrajnohuAPI.Data.DTOs
{
    public class GetTrainingDayDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<GetExerciseDTO>? Exercises { get; set; }
    }

    public class AddTrainingDTO
    {
        public string Name { get; set; } = null!;
        public ICollection<int>? ExerciseIds { get; set; }
    }
}
