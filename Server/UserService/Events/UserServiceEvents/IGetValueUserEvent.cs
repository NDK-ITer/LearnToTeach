namespace Events.UserServiceEvents
{
    public interface IGetValueUserEvent
    {
        public Guid id { get; set; }
        public string? fullName { get; set; }
        public string? email { get; set; }
        public string? content { get; set; }
        public string? eventMessage { get; set; }
    }
}
