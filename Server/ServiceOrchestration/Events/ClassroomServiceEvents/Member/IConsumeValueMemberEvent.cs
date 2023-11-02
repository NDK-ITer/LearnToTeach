namespace Events.ClassroomServiceEvents.Member
{
    public interface IConsumeValueMemberEvent
    {
        public Guid idClassroom { get; }
        public string IdMember { get; }
    }
}
