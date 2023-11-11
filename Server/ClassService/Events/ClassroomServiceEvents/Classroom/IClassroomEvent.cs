namespace Events.ClassroomServiceEvents.Classroom
{
    public interface IClassroomEvent
    {
        public Guid idClassroom { get; }
        public string? description { get; }
        public string? idUserHost { get; }
        public string? name { get; }
        public bool isPrivate { get; }
        public string eventMessage { get; }
    }
}
