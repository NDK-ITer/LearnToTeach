namespace Events.StoreFileServiceEvent
{
    public interface IConsumerUploadFileEvent
    {
        public string FileByteString { get; }
        public string Event { get; }
        public string ServerName { get; }
    }
}
