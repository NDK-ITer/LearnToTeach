namespace Events.ClassroomServiceEvents.Classroom
{
    public interface IAddClassroomIsValidEvent
    {
        public Guid idClassroom { get; }
        public string? idUserHost { get; }
        public string? nameUserHost { get; }
        public string? avatar { get; }
    }
}
