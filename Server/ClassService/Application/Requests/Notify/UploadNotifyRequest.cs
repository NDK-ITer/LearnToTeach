namespace Application.Requests.Notify
{
    public class UploadNotifyRequest
    {
        public string ?IdClassroom { get; set; }
        public string? IdMember { get; set; }
        public string ?NameNotify { get; set; }
        public string? Decription { get; set; }
    }
}
