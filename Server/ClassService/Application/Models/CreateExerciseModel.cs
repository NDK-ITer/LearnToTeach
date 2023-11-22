namespace Application.Models
{
    public class CreateExerciseModel
    {
        public string IdExercise { get; set; }
        public string IdClassroom { get; set; }
        public string IdMember { get; set; }
        public string? Name { get; set; }
        public string? LinkFile { get; set; }
        public string? FileName { get; set; }
        public string? Description { get; set; }
        public DateTime? Deadline { get; set; }
    }
}
