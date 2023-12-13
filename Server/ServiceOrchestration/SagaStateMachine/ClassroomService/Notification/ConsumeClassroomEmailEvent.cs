using Event.ClassroomServiceEvents.Notification;

namespace SagaStateMachine.ClassroomService.Notification
{
    public class ConsumeClassroomEmailEvent : IConsumeClassroomEmail
    {
        private readonly ClassroomEmailStateData classroomEmail;
        public ConsumeClassroomEmailEvent(ClassroomEmailStateData classroomEmail)
        {
            this.classroomEmail = classroomEmail;
        }

        public string Email  => classroomEmail.Email;
        public string Subject => classroomEmail.Subject;
        public string Content => classroomEmail.Content;
    }
}
