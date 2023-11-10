namespace Events.UserServiceEvents.User.ConfirmUser
{
    public interface IConfirmUserEvent
    {
        public Guid idUser { get; }
        public string fullName { get; }
        public string email { get; }
        public string subject { get; }
        public string content { get; }
    }
}
