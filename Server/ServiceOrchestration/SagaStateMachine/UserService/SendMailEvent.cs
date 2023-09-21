using Events.UserServiceEvents.Notification;

namespace SagaStateMachine.UserService
{
    public class SendMailEvent : ISendEmailEvent
    {
        private readonly UserStateData userStateData;

        public SendMailEvent(UserStateData userStateData)
        {
            this.userStateData = userStateData;
        }
        public Guid id => userStateData.IdUser;
        public string FullName => userStateData.Fullname;
        public string Email => userStateData.Email;
        public string Subject => userStateData.Subject;
        public string Content => userStateData.Content;

    }
}
