using MassTransit;

namespace SagaStateMachine.ClassroomService.Classroom
{
    public class ClassroomStateData : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string? CurrentState { get; set; }
        public Guid IdMessage { get; set; }
        public string IdClassroom { get; set; }
        public string? IdUserHost { get; set; }
        public string? Avatar { get; set; }
        public string? LinkAvatar { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsPrivate { get; set; }
        public string EventMessage { get; set; }
    }
}
