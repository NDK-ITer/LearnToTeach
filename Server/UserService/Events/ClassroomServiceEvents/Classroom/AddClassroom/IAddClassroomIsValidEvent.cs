namespace Events.ClassroomServiceEvents.Classroom.AddClassroom
{
    public interface IAddClassroomIsValidEvent
    {
        public Guid idClassroom { get; }
        public string? idUserHost { get; }
        public string? nameUserHost { get; }
        public string? avatar { get; }
        public string? linkAvatar { get; }
    }
}
