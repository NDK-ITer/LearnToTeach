namespace MeetingServer.DTOs
{
    public class UserConnection
    {
        public string UserName { get; set; }
        public string IdClassroom { get; set; }
        public UserConnection(string userName, string idClassroom)
        {
            UserName = userName;
            IdClassroom = idClassroom;

        }
    }
}
