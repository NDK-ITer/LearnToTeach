namespace Events.UserServiceEvents.User.ConfirmUser
{
    public interface IConfirmUserEvent
    {
        public Guid idUser { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string content { get; set; }
    }
}
