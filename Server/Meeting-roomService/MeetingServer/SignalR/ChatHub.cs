using MeetingServer.DTOs;
using Microsoft.AspNetCore.SignalR;

namespace MeetingServer.SignalR
{
    public class ChatHub : Hub
    {
        private readonly string _botUser;
        private readonly IDictionary<string, UserConnection> _connections;

        public ChatHub(IDictionary<string, UserConnection> connections)
        {
            _botUser = "MyChat Bot";
            _connections = connections;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            if (_connections.TryGetValue(Context.ConnectionId, out UserConnection userConnection))
            {
                _connections.Remove(Context.ConnectionId);
                Clients.Group(userConnection.IdClassroom).SendAsync("ReceiveMessage", _botUser, $"{userConnection.UserName} has left");
                SendUsersConnected(userConnection.IdClassroom);
            }

            return base.OnDisconnectedAsync(exception);
        }

        public async Task JoinRoom(UserConnection userConnection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.IdClassroom);

            _connections[Context.ConnectionId] = userConnection;

            await Clients.Group(userConnection.IdClassroom).SendAsync("ReceiveMessage", _botUser, $"{userConnection.UserName} has joined {userConnection.IdClassroom}");

            await SendUsersConnected(userConnection.IdClassroom);
        }

        public async Task SendMessage(string message)
        {
            if (_connections.TryGetValue(Context.ConnectionId, out UserConnection userConnection))
            {
                await Clients.Group(userConnection.IdClassroom).SendAsync("ReceiveMessage", userConnection.UserName, message);
            }
        }

        public async Task SendVideoAndAudio(string videoRef, string mediaRecorderRef)
        {

        }

        public Task SendUsersConnected(string room)
        {
            var users = _connections.Values
                .Where(c => c.IdClassroom == room)
                .Select(c => c.UserName);
            //var result = Clients.Group(room).SendAsync("UsersInRoom", users);
            return Clients.Group(room).SendAsync("UsersInRoom", users);
        }
    }
}
