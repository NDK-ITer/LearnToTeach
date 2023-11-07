using MassTransit;
using Events.ClassroomServiceEvents.Models;

namespace SagaStateMachine.ClassroomService.Member
{
    public class AddMemberStateData : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string? CurrentState { get; set; }
        public Guid IdClassroom { get; set; }
        public List<MemberEventModel>? ListMember { get; set; }
    }
}
