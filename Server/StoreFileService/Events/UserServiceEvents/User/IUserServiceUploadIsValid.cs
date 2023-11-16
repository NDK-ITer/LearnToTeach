namespace Events.UserServiceEvents.User
{
    public interface IUserServiceUploadIsValid
    {
        public Guid Id { get; }
        public string Link { get; }
        public string NameImage { get; }
    }
}
