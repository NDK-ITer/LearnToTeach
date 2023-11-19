namespace Events.ClassroomServiceEvents.Classroom
{
    public interface IClassroomServiceUploadIsValid
    {
        public Guid Id { get; }
        public string LinkImage { get; }
        public string NameImage { get; }
    }
}
