using MassTransit;

namespace SagaStateMachine.UserService
{
    public class UserStateData : SagaStateMachineInstance
    {
        public Guid CorrelationId { get ; set; }
        public string? CurrentState { get; set; }
        public Guid IdUser { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
    }
}
