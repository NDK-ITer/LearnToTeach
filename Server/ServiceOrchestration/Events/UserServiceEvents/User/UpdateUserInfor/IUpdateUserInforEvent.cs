namespace Events.UserServiceEvents.User.UpdateUserInfor
{
    public interface IUpdateUserInforEvent
    {
        public Guid IdUser { get; }
        public string FullName { get; }
        public string Avatar { get; }
        public string LinkAvatar { get; }
    }
}
