namespace Events.ClassroomServiceEvents.Classroom
{
    public interface IClassroomServiceUploadIsValid
    {
        public Guid IdMessage { get; }
        public string IdClassroom { get; }
        public string LinkImage { get; }
        public string NameImage { get; }
    }
}
