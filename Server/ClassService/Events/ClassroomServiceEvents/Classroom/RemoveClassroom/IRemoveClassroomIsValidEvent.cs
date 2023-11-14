namespace Events.ClassroomServiceEvents.Classroom.RemoveClassroom
{
    public interface IRemoveClassroomIsValidEvent
    {
        public Guid IdClassroom { get; }
    }
}
