using Microsoft.AspNetCore.SignalR;

namespace MeetingServer.SignalR
{
    public class YourHub : Hub
    {
        public async Task SendMessage(string userToCall, object signalData, string from, string name)
        {
            await Clients.Client(userToCall).SendAsync("ReceiveCall", signalData, from, name);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("ReceiveId", Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.Others.SendAsync("CallEnded");
            await base.OnDisconnectedAsync(exception);
        }
    }
}
