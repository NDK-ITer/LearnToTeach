namespace Events.ClassroomServiceEvents.Member
{
    public interface ICancelAddMemberEvent
    {
        public Guid idClassroom { get; set; }
        public string IdMember { get; set; }
    }
}
