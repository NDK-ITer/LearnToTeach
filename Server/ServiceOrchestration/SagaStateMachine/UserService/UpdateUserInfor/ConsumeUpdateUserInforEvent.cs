using Events.UserServiceEvents.DataSynchronization;

namespace SagaStateMachine.UserService.UpdateUserInfor
{
    public class ConsumeUpdateUserInforEvent : IConsumeUserInforEvent
    {
        private readonly UpdateUserInforStateData updateUserInforStateData;
        public ConsumeUpdateUserInforEvent(UpdateUserInforStateData updateUserInforStateData) 
        {
            this.updateUserInforStateData = updateUserInforStateData;
        }
        public Guid IdUser => updateUserInforStateData.IdUser;
        public string FullName => updateUserInforStateData.FullName;
        public string Avatar => updateUserInforStateData.Avatar;
    }
}
