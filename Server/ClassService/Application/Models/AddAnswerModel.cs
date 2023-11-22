namespace Application.Models
{
    public class AddAnswerModel
    {
        public string? IdMember { get; set; }
        public string? IdExercise { get; set; }
        public string Content { get; set; }
        public string? LinkFile { get; set; }
        public string? FileName { get; set; }
    }
}
