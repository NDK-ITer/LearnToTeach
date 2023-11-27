namespace Events.StoreFileServiceEvent
{
    public interface IConsumerUploadFileEvent
    {
        public Guid IdMessage { get; }
        public string IdObject { get; }
        public string FileByteString { get; }
        public string Event { get; }
        public string ServerName { get; }
    }
}
