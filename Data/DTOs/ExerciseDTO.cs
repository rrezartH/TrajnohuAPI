namespace TrajnohuAPI.Data.DTOs
{
    public class GetExerciseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string BodyTarget { get; set; } = null!;
        public string BodyPart { get; set; } = null!;
        public string Equipment { get; set; } = "Peshe Trupore";
        public string? GifURL { get; set; }
        public bool IsHomeExercise { get; set; }
    }

    public class AddExerciseDTO
    {
        public string Name { get; set; } = null!;
        public string BodyTarget { get; set; } = null!;
        public string BodyPart { get; set; } = null!;
        public string Equipment { get; set; } = "Peshe Trupore";
        public string? GifURL { get; set; }
        public bool IsHomeExercise { get; set; }
    }

    public class UpdateExerciseDTO
    {
        public string? Name { get; set; }
        public string? BodyTarget { get; set; }
        public string? BodyPart { get; set; }
        public string? Equipment { get; set; }
        public string? GifURL { get; set; }
        public bool IsHomeExercise { get; set; }

    }
}
