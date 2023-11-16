namespace Events.StoreFileServiceEvent
{
    public interface IConsumerUploadFileEvent
    {
        public Guid Id { get; }
        public string FileByteString { get; }
        public string Event { get; }
        public string ServerName { get; }
    }
}
