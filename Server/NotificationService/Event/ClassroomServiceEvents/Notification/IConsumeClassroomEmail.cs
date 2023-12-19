namespace Event.ClassroomServiceEvents.Notification
{
    public interface IConsumeClassroomEmail
    {
        public string Email { get; }
        public string Subject { get;}
        public string Content { get; }
    }
}
