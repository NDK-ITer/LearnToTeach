using MassTransit;

namespace SagaStateMachine.ClassroomService.Member
{
    public class MemberStateData : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string? CurrentState { get; set; }
        public Guid IdMessage { get; set; }
        public string? IdClassroom { get; set; }
        public string? IdMember { get; set; }
        public string? NameClassroom { get; set; }
        public string? NameMember { get; set; }
        public string? Avatar { get; set; }
        public string? Event { get; set; }
    }
}
