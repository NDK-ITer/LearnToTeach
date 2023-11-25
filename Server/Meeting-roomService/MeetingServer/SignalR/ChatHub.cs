using Microsoft.AspNetCore.SignalR;

namespace MeetingServer.SignalR
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("me", Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            Console.WriteLine($"Socket {Context.ConnectionId} is disconnected...");
            await Clients.Others.SendAsync("callended");
            await base.OnDisconnectedAsync(exception);
        }

        public async Task CallUser(string userToCall, object signalData, string from, string name)
        {
            await Clients.Client(userToCall).SendAsync("calluser", new { signal = signalData, from, name });
        }

        //public async Task AnswerCall(object data)
        //{
        //    var to = Context.ConnectionId;
        //    await Clients.Client(data.to).SendAsync("callaccepted", data.signal);
        //}
    }
}
