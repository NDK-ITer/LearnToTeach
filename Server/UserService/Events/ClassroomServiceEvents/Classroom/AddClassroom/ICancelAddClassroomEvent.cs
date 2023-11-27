namespace Events.ClassroomServiceEvents.Classroom.AddClassroom
{
    public interface ICancelAddClassroomEvent
    {
        public Guid idMessage { get; }
        public string idClassroom { get; }
        public string? description { get; }
        public string? idUserHost { get; }
        public string? name { get; }
        public bool isPrivate { get; }
    }
}
