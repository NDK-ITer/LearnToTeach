namespace Events.ClassroomServiceEvents.Member
{
    public interface IGetValueMemberEvent
    {

        public Guid IdMessage { get; }
        public string IdClassroom { get; }
        public string IdMember { get; }
        public string NameClassroom { get; }
        public string NameMember { get; }
        public string Avatar { get; }
        public string eventMessage { get; }

    }
}
