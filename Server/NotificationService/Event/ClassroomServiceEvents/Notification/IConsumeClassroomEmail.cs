namespace Event.ClassroomServiceEvents.Notification
{
    public interface IConsumeClassroomEmail
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Content { get; }
    }
}
