using Events.ClassroomServiceEvents.Classroom;

namespace SagaStateMachine.ClassroomService.Classroom.AddClassroom
{
    public class ConsumeValueAddClassroomEvent : IConsumeValueClassroomEvent
    {
        private readonly AddClassroomStateData classroomStateData;

        public ConsumeValueAddClassroomEvent(AddClassroomStateData classroomStateData)
        {
            this.classroomStateData = classroomStateData;
        }
        public Guid idClassroom => classroomStateData.IdClassroom;
        public string? description => classroomStateData.Description;
        public string? idUserHost => classroomStateData.IdUserHost;
        public string? name => classroomStateData.Name;
        public bool isPrivate => classroomStateData.IsPrivate;
    }
}
