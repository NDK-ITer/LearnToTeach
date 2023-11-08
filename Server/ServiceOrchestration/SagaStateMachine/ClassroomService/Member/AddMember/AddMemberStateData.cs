using MassTransit;
using Events.ClassroomServiceEvents.Models;
using SagaStateMachine.ClassroomService.Member.AddMember;

namespace SagaStateMachine.ClassroomService.Member
{
    public class AddMemberStateData : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string? CurrentState { get; set; }
        public Guid IdClassroom { get; set; }
        public string NameClassroom { get; set; }
        public List<MemberModel> ListMember { get; set; }
    }
}
