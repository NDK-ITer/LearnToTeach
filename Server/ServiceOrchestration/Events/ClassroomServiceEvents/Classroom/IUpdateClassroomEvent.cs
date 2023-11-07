namespace Events.ClassroomServiceEvents.Classroom
{
    public interface IUpdateClassroomEvent
    {
        public Guid idClassroom { get; }
        public string? description { get; }
        public string? name { get; }
    }
}
