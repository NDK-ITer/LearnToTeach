namespace Events.ClassroomServiceEvents
{
    public interface IClassroomSendEmail
    {
        public Guid IdMessage { get; }
        public string Email { get; }
        public string Subject { get; }
        public string Content { get; }
    }
}
