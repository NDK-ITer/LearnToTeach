namespace Application.Requests.Notify
{
    public class UpdateNotifyRequest
    {
        public string IdClassroom { get; set; }
        public string IdMember { get; set; }
        public string IdNotify { get; set; }
        public string NameNotify { get; set; }
        public string Description { get; set; }
    }
}
