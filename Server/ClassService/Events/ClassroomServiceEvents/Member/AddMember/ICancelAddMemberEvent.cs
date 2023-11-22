namespace Events.ClassroomServiceEvents.Member.AddMember
{
    public interface ICancelAddMemberEvent
    {
        public Guid IdClassroom { get; }
        public string IdMember { get; }
    }
}
