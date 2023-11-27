namespace Events.ClassroomServiceEvents.Member
{
    public interface IMemberEvent
    {
        public Guid IdMessage { get; }
        public string IdClassroom { get; }
        public string IdMember { get; }
        public string NameClassroom { get; }
        public string NameMember { get; }
        public string Avatar { get; }
        public string Event { get; }
    }
}
