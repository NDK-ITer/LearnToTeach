using Events.ClassroomEvents;
using MassTransit;

namespace SagaStateMachine.Classrooms
{
    public class ClassroomStateData : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string? CurrentState { get; set; }
        public DateTime ClassroomCreatedDate { get; set; }
        public Guid IdClassroom { get; set; }
        public string? description { get; set; }
        public string? idUserHost { get; set; }
        public string? key { get; set; }
        public string? name { get; set; }
        public bool isPrivate { get; set; }
        public List<MemberModel>? Members { get; set; }
    }
}
