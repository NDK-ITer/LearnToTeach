using Microsoft.AspNetCore.SignalR;

namespace MeetingServer.SignalR
{
    public class TrackingHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
