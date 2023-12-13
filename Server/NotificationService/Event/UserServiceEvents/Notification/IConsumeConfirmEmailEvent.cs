namespace Events.UserServiceEvents.Notification
{
    public interface IConsumeConfirmEmailEvent
    {
        public Guid id { get; }
        public string FullName { get; }
        public string Email { get; }
        public string Subject { get; set; }
        public string Content { get; }
    }
}
