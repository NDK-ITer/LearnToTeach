namespace Events.UserServiceEvents
{
    public interface IGetValueUserEvent
    {
        public Guid id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public string eventMessage { get; set; }
    }
}
