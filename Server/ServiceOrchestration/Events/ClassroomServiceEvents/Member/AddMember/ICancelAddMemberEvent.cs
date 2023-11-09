namespace Events.ClassroomServiceEvents.Member.AddMember
{
    public interface ICancelAddMemberEvent
    {
        public Guid IdClassroom { get; }
        public string IdMember { get; }
        public string NameClassroom { get; }
        public string NameMember { get; }
        public string Avatar { get; }

    }
}
