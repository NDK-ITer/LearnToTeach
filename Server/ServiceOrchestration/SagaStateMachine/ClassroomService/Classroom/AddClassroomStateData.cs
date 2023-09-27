using MassTransit;

namespace SagaStateMachine.ClassroomService.Classroom
{
    public class AddClassroomStateData : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string? CurrentState { get; set; }
        public Guid IdClassroom { get; set; }
        public string? Description { get; set; }
        public string? IdUserHost { get; set; }
        public string? Name { get; set; }
        public bool IsPrivate { get; set; }
    }
}
