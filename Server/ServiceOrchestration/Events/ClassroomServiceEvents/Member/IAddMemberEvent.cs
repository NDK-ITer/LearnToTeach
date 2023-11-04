namespace Events.ClassroomServiceEvents.Member
{
    public interface IAddMemberEvent
    {
        public Guid IdClassroom { get; }
        public string IdMember { get; }
        
    }
}
