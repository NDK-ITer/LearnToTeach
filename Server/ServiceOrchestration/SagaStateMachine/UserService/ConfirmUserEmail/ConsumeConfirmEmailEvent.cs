using Events.UserServiceEvents.Notification;

namespace SagaStateMachine.UserService.ConfirmUserEmail
{
    public class ConsumeConfirmEmailEvent : IConsumeConfirmEmailEvent
    {
        private readonly ConfirmUserEmailStateData userStateData;

        public ConsumeConfirmEmailEvent(ConfirmUserEmailStateData userStateData)
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
