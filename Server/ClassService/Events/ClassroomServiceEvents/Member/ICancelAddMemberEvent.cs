namespace Events.ClassroomServiceEvents.Member
{
    public interface ICancelAddMemberEvent
    {
        public Guid IdClassroom { get; }
        public List<string> ListMember { get; }
        
    }
}
