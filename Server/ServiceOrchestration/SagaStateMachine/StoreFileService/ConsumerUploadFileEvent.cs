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

        public Guid IdMessage => uploadFileStateData.IdMessage;

        public string IdObject => uploadFileStateData.IdObject;

        public string FileByteString => uploadFileStateData.FileByteString;

        public string Event => uploadFileStateData.Event;

        public string ServerName => uploadFileStateData.ServerName;
    }
}
