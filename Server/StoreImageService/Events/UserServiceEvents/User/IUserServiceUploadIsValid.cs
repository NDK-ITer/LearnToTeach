namespace Events.UserServiceEvents.User
{
    public interface IUserServiceUploadIsValid
    {
        public Guid IdMessage { get; }
        public string IdUser { get; }
        public string LinkImage { get; }
        public string NameImage { get; }
    }
}
