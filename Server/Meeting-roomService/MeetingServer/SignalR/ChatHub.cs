using Microsoft.AspNetCore.SignalR;

namespace MeetingServer.SignalR
{
    public class ChatHub : Hub
    {
        private readonly PresenceTracker _presenceTracker;

        public ChatHub(PresenceTracker presenceTracker) 
        {
            _presenceTracker = presenceTracker;
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }
    }
}
