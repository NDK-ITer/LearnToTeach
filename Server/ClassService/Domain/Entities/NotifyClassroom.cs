namespace Domain.Entities
{
    public class NotifyClassroom
    {
        public string IdNotify { get; set; }
        public DateTime? CreateDate { get; set; }
        public string NameNotify { get; set; }
        public string Description { get; set; }
        public string IdClassroom { get; set; }
        public Classroom Classroom { get; set; }
    }
}
