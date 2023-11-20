namespace Events.ClassroomServiceEvents.Classroom
{
    public interface IGetValueClassroomEvent
    {
        public Guid idClassroom { get; }
        public string avatar { get; }
        public string? description { get; }
        public string? idUserHost { get; }
        public string? name { get; }
        public string? serverName { get; }
        public bool isPrivate { get; }
        public string eventMessage { get; }
    }
}
