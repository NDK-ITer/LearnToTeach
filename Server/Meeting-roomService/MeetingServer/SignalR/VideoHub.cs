using Microsoft.AspNetCore.SignalR;

namespace MeetingServer.SignalR
{
    public class VideoHub : Hub
    {
        public async Task CallUser(string targetUserId, string signal)
        {
            await Clients.User(targetUserId).SendAsync("ReceiveCall", signal);
        }

        public async Task AnswerCall(string targetConnectionId, string signal)
        {
            await Clients.Client(targetConnectionId).SendAsync("ReceiveAnswer", signal);
        }
    }
}
