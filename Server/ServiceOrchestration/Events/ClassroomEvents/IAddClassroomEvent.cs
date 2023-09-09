namespace Events.ClassroomEvents
{
    public class MemberModel
    {
        public string idMember { get; set; }
        public string? role { get; set; }
        public string? description { get; set; }
    }
    public interface IAddClassroomEvent
    {
        public Guid idClassroom { get; set; }
        public string? description { get; set; }
        public string? idUserHost { get; set; }
        public string? key { get; set; }
        public string? name { get; set; }
        public bool isPrivate { get; set; }
        public List<MemberModel>? Members { get; set; }
    }
}
