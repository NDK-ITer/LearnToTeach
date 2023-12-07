using FM.LiveSwitch;

namespace MeetingServer.DTOs
{
    public class UserConnection
    {
        public string userName { get; set; }
        public string classroom { get; set; }
        public VideoStream? videoRef { get; set; }
        public AudioStream? audioRef { get; set; }
    }
}
