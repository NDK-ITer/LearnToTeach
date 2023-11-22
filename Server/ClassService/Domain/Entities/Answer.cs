namespace Domain.Entities
{
    public class Answer
    {
        public string? IdMember { get; set; }
        public string? IdExercise { get; set; }
        public DateTime DateAnswer { get; set; }
        public string? Content { get; set; }
        public string? LinkFile { get; set; }
        public string? FileName { get; set; }
        public Member? Member { get; set; }
        public Exercise? Exercise { get; set; }
    }
}
