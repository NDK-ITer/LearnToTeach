namespace Events.ClassroomServiceEvents.Member
{
    public interface IUserInforUpdatedEvent
    {
        public Guid IdClassroom { get; }
        public string IdMember { get; }
        public string NameMember { get; }
        public string Avatar { get; }
    }
}
