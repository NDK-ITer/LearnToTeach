using MassTransit;

namespace SagaStateMachine.StoreFileService
{
    public class UploadFileStateData : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string? CurrentState { get; set; }
        public Guid Id { get; set; }
        public string FileByteString { get; set; }
        public string Event { get; set; }
        public string ServerName { get; set; }
    }
}
