namespace MeetingServer.DTOs
{
    public class UserConnection
    {
        public string userName { get; set; }
        public string classroom { get; set; }
        public object? videoRef { get; set; }
        public object? audioRef { get; set; }
    }
}
