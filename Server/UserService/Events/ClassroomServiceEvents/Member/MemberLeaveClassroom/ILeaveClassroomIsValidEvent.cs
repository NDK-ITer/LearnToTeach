namespace Events.ClassroomServiceEvents.Member.MemberLeaveClassroom
{
    public interface ILeaveClassroomIsValidEvent
    {
        public string IdClassroom { get; }
        public string IdUser { get; }
    }
}
