namespace Events.ClassroomServiceEvents.Member
{
    public interface IAddMemberEvent
    {
        public Guid idClassroom { get; }
        public string IdMember { get; }
    }
}
