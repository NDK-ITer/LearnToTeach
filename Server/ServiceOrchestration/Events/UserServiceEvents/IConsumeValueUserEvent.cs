namespace Event.UserEvents
{
    public interface IConsumeValueUserEvent
    {
        public Guid id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
    }
}
