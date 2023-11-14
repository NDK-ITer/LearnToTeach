namespace Events.MultiServiceUseEvent
{
    public interface IUploadFileEvent
    {
        public string FileByteString { get; }
        public string Event { get; }
        public string ServerName { get; }

    }
}
