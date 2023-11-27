using Events.ClassroomServiceEvents.Classroom;

namespace SagaStateMachine.ClassroomService.Classroom
{
    public class ConsumeValueClassroomEvent : IConsumeValueClassroomEvent
    {
        private readonly ClassroomStateData classroomStateData;

        public ConsumeValueClassroomEvent(ClassroomStateData classroomStateData)
        {
            this.classroomStateData = classroomStateData;
        }
        public Guid idMessage => classroomStateData.IdMessage;
        public string idClassroom => classroomStateData.IdClassroom;
        public string? description => classroomStateData.Description;
        public string? idUserHost => classroomStateData.IdUserHost;
        public string? name => classroomStateData.Name;
        public string? avatar => classroomStateData.Avatar;
        public string? linkAvatar => classroomStateData.LinkAvatar;
        public string? eventMessage => classroomStateData.EventMessage;
        public bool isPrivate => classroomStateData.IsPrivate;
    }
}
