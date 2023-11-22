using MassTransit;

namespace SagaStateMachine.StoreFileService
{
    public class UploadFileStateData : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string? CurrentState { get; set; }
        public Guid IdMessage { get; set; }
        public string IdObject { get; set; }
        public string FileByteString { get; set; }
        public string Event { get; set; }
        public string ServerName { get; set; }
    }
}
