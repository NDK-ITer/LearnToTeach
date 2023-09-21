namespace Events.UserServiceEvents.Notification
{
    public interface ISendEmailEvent
    {
        public Guid id { get; }
        public string FullName { get; }
        public string Email { get; }
        public string Content { get; }
    }
}
