namespace Events.MultiServiceUseEvent
{
    public interface IUploadFileEvent
    {
        public Guid Id { get; }
        public string FileByteString { get; }
        public string Event { get; }
        public string ServerName { get; }

    }
}
