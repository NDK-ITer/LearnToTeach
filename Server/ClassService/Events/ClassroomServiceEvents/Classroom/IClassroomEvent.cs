namespace Events.ClassroomServiceEvents.Classroom
{
    public interface IClassroomEvent
    {
        public Guid idMessage { get; }
        public string idClassroom { get; }
        public string? description { get; }
        public string? idUserHost { get; }
        public string? name { get; }
        public string? avatar { get; }
        public string? linkAvatar { get; }
        public bool isPrivate { get; }
        public string eventMessage { get; }
    }
}
