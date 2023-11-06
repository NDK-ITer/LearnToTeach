namespace Events.ClassroomServiceEvents.Member
{
    public interface ICancelAddMemberEvent
    {
        public Guid IdClassroom { get; set; }
        public string IdMember { get; set; }
        public string? NameMember { get; }
        public string? Avatar { get; }
    }
}
