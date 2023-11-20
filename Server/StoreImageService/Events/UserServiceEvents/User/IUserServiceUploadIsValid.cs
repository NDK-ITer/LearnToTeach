namespace Events.UserServiceEvents.User
{
    public interface IUserServiceUploadIsValid
    {
        public Guid Id { get; }
        public string LinkImage { get; }
        public string NameImage { get; }
    }
}
