namespace Domain.Entities
{
    public class LearningDocument
    {
        public string NameFile { get; set; }
        public string Description { get; set; }
        public string LinkFile { get; set; }
        public string IdClassroom { get; set; }
        public DateTime UploadDate { get; set; }
        public Classroom Classroom { get; set; }
    }
}
