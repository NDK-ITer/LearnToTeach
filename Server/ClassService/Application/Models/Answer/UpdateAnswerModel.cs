namespace Application.Models.Answer
{
    public class UpdateAnswerModel
    {
        public string IdExercise { get; set; }
        public string IdMember { get; set; }
        public string? Content { get; set; }
        public string? LinkFile { get; set; }
        public string? FileName { get; set; }
    }
}
