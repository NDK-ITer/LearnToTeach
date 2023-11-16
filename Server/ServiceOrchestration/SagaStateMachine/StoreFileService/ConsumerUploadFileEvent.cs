using Events.StoreFileServiceEvent;

namespace SagaStateMachine.StoreFileService
{
    public class ConsumerUploadFileEvent : IConsumerUploadFileEvent
    {
        private readonly UploadFileStateData uploadFileStateData;

        public ConsumerUploadFileEvent(UploadFileStateData uploadFileStateData)
        {
            this.uploadFileStateData = uploadFileStateData;
        }

        public Guid Id => uploadFileStateData.Id;

        public string FileByteString => uploadFileStateData.FileByteString;

        public string Event => uploadFileStateData.Event;

        public string ServerName => uploadFileStateData.ServerName;
    }
}
