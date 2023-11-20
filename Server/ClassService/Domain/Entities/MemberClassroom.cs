namespace Domain.Entities
{
    public class MemberClassroom
    {
        public string IdUser { get; set; }
        public string IdClass { get; set; }
        public string? Role { get; set; }
        public string? Description { get; set; }
        public Classroom? Classroom { get; set; }
        public Member? Member { get; set; }
    }
}
