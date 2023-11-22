namespace Application.Models
{
    public class UpdateExerciseModel
    {
        public string IdExercise { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? Deadline { get; set; }
    }
}
