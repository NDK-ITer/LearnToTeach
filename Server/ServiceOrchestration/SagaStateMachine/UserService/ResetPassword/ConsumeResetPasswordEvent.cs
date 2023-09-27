using Events.UserServiceEvents.Notification;

namespace SagaStateMachine.UserService.ResetPassword
{
    public class ConsumeResetPasswordEvent : IConsumeConfirmEmailEvent
    {
        private readonly ResetPasswordStateData userStateData;

        public ConsumeResetPasswordEvent(ResetPasswordStateData userStateData)
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
