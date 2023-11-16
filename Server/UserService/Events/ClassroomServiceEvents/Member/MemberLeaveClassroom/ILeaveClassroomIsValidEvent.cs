namespace Events.ClassroomServiceEvents.Member.MemberLeaveClassroom
{
    public interface ILeaveClassroomIsValidEvent
    {
        public Guid IdClassroom { get; }
        public string IdUser { get; }
    }
}
