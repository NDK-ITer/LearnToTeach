namespace Events.ClassroomServiceEvents.Member
{
    public interface ICancelAddMemberEvent
    {
        public Guid idClassroom { get; }
        public string IdMember { get; }
        public string? NameMember { get; }
        public string? Avatar { get; }
    }
}
