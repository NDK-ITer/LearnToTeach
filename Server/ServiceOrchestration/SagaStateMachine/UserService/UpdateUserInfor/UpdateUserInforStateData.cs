using MassTransit;

namespace SagaStateMachine.UserService.UpdateUserInfor
{
    public class UpdateUserInforStateData : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set ; }
        public string? CurrentState { get; set; }
        public Guid IdUser { get; set; }
        public string? FullName { get; set; }
        public string? Avatar { get; set;}
    }
}
