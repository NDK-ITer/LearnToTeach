using MassTransit;

namespace SagaStateMachine.ClassroomService.Member
{
    public class MemberStateData : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string? CurrentState { get; set; }
        public Guid IdClassroom { get; set; }
        public string? IdMember { get; set; }
    }
}
