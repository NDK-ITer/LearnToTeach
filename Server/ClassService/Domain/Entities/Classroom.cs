namespace Domain.Entities
{
    public class Classroom
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
        public string? KeyHash { get; set; }
        public string? IdUserHost { get; set; }
        public string? NameUserHost { get; set; }
        public string? AvatarUserHost { get; set; }
        public bool IsPrivate { get; set; }
        public List<ClassroomDetail>? ListUserId { get; set; }
    }
}
