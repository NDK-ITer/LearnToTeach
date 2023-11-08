namespace Events.ClassroomServiceEvents.Member.AddMember
{
    public interface ICancelAddMemberEvent
    {
        public Guid IdClassroom { get; }
        public string NameClassroom { get; }
        public List<string> ListMember { get; }

    }
}
