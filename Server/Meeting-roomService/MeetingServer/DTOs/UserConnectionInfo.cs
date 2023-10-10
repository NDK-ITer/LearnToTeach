namespace MeetingServer.DTOs
{
    public class UserConnectionInfo
    {
        public string UserName { get; set; }
        public string ClassroomId { get; set; }
        public UserConnectionInfo(string userName, string classroomId)
        {
            UserName = userName;
            ClassroomId = classroomId;

        }
    }
}
