using MassTransit;

namespace SagaStateMachine.ClassroomService.Notification
{
    public class ClassroomEmailStateData : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string? CurrentState { get; set; }
        public Guid IdMessage { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
