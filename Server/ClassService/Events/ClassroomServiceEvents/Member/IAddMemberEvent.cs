namespace Events.ClassroomServiceEvents.Member
{
    public interface IAddMemberEvent
    {
        public Guid IdClassroom { get; }
        public List<string> ListMember { get; }
        public string? NameMember { get; }
        public string? Avatar { get; }

    }
}
