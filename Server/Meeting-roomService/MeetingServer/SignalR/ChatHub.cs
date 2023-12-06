using MeetingServer.DTOs;
using Microsoft.AspNetCore.SignalR;

namespace MeetingServer.SignalR
{
    public class ChatHub : Hub
    {
        private readonly string _botUser = "MyChat Bot";
        private readonly IDictionary<string, UserConnection> _connections;

        public ChatHub(IDictionary<string, UserConnection> connections)
        {
            _connections = connections;
        }

        public async Task SendUsersConnected(string classroom)
        {

        }

        public async Task JoinRoom(UserConnection userConnection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.classroom);

            _connections[Context.ConnectionId] = userConnection;

            await Clients.Group(userConnection.classroom).SendAsync("ReceiveMessage", _botUser, $"{userConnection.userName} has joined {userConnection.classroom}");

            await SendUsersConnected(userConnection.userName);
        }

    }
}
