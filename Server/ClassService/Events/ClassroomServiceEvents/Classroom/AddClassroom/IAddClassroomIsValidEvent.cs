namespace Events.ClassroomServiceEvents.Classroom.AddClassroom
{
    public interface IAddClassroomIsValidEvent
    {
        public Guid idMessage { get; }
        public string idClassroom { get; }
        public string? idUserHost { get; }
        public string? nameUserHost { get; }
        public string? avatarClassroom { get; }
        public string? avatarMember { get; }
        public string? linkAvatar { get; }
        public string? email { get; }
    }
}
