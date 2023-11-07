namespace Events.ClassroomServiceEvents.Member
{
    public interface IGetValueMemberEvent
    {
        public Guid IdClassroom { get; }
        public List<string> ListMember { get; }
        public string NameMember { get; }
        public string Avatar { get; }
        public string eventMessage { get; }
    }
}
