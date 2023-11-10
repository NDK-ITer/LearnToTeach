namespace Events.UserServiceEvents.DataSynchronization
{
    public interface IConsumeUserInforEvent
    {
        public Guid IdUser { get; }
        public string FullName { get; }
        public string Avatar { get; }
    }
}
