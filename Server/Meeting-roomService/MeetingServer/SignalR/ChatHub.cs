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

        public Task SendUsersConnected(string classroom)
        {
            var users = _connections.Values.Where(c => c.classroom == classroom).ToList();
            return Clients.Group(classroom).SendAsync("UsersInRoom", users);
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
