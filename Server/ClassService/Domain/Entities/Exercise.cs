namespace Domain.Entities
{
    public class Exercise
    {
        public string? IdExercise { get; set; }
        public DateTime CreateDate { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? LinkFile { get; set; }
        public string? IdClassroom { get; set; }
        public Classroom? Classroom { get; set; }
        public List<Answer>? ListAnswer { get; set; }
    }
}
