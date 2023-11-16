namespace Events.ClassroomServiceEvents.Classroom
{
    public interface IClassroomServiceUploadIsValid
    {
        public Guid Id { get; }
        public string Link { get; }
        public string NameImage { get; }
    }
}
