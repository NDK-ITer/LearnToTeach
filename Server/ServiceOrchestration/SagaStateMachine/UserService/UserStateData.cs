using MassTransit;

namespace SagaStateMachine.UserService
{
    public class UserStateData : SagaStateMachineInstance
    {
        public Guid CorrelationId { get ; set; }
        public string? CurrentState { get; set; }
        public string id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsLock { get; set; }
        public string TokenAccess { get; set; }
        public string RoleId { get; set; }
    }
}
