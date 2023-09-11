namespace Events.ClassroomEvents
{
    public interface ICancelAddClassroomEvent
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
