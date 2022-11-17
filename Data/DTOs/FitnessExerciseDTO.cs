namespace TrajnohuAPI.Data.DTOs
{
    public class GetFitnessExerciseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string BodyTarget { get; set; } = null!;
        public string BodyPart { get; set; } = null!;
        public string Equipment { get; set; } = "Peshe Trupore";
        public string? GifURL { get; set; }
    }

    public class AddFitnessExerciseDTO
    {
        public string Name { get; set; } = null!;
        public string BodyTarget { get; set; } = null!;
        public string BodyPart { get; set; } = null!;
        public string Equipment { get; set; } = "Peshe Trupore";
        public string? GifURL { get; set; }
    }

    public class UpdateFitnesExerciseDTO
    {
        public string? Name { get; set; }
        public string? BodyTarget { get; set; }
        public string? BodyPart { get; set; }
        public string? Equipment { get; set; }
        public string? GifURL { get; set; }
    }
}
