namespace Events.ClassroomServiceEvents.Member.AddMember
{
    public interface IAddMemberIsValidEvent
    {
        public string IdClassroom { get; }
        public string IdMember { get; }
        public string NameMember { get; }
        public string EmailMember { get; }
        public string Avatar { get; }
        public string LinkAvatar { get; }
    }
}
