namespace Events.ClassroomServiceEvents.Member.AddMember
{
    public interface IAddMemberEvent
    {
        public Guid IdClassroom { get; }
        public string IdMember { get; }
        public string NameClassroom { get; }
        public string NameMember { get; }
        public string Avatar { get; }
    }
}
