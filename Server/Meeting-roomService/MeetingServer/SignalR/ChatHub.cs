using MeetingServer.DTOs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Runtime.CompilerServices;

namespace MeetingServer.SignalR
{
    public class ChatHub : Hub
    {
        private readonly string _botUser = "MyChat Bot";
        private readonly IDictionary<string, UserConnection> _connections;
        protected IWebHostEnvironment environment;
        //private Tuple<string, string>? SaveImage(string folder, string imgStringBase64, string imgName)
        //{
        //    try
        //    {
        //        var contentPath = environment.ContentRootPath;
        //        var path = $"{Path.Combine(contentPath, folder)}\\{imgName}.png";
        //        string base64String = imgStringBase64;
        //        byte[] imageBytes = Convert.FromBase64String(base64String);
        //        File.WriteAllBytes(path, imageBytes);
        //        var linkServer = $"";
        //        var imageName = $"{imgName}.png";
        //        var result = new Tuple<string, string>(linkServer, imageName);
        //        return result;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}
        public ChatHub(IDictionary<string, UserConnection> connections, IWebHostEnvironment environment)
        {
            _connections = connections;
            this.environment = environment;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            if (_connections.TryGetValue(Context.ConnectionId, out UserConnection userConnection))
            {
                _connections.Remove(Context.ConnectionId);
                Clients.Group(userConnection.classroom).SendAsync("ReceiveMessage", _botUser, $"{userConnection.userName} has left");
                SendUsersConnected(userConnection.classroom);
            }

            return base.OnDisconnectedAsync(exception);
        }


        public Task SendUsersConnected(string classroom)
        {
            var users = _connections.Values.Where(c => c.classroom == classroom).ToList();
            return Clients.Group(classroom).SendAsync("UsersInRoom", users);
        }

        public async Task JoinRoom(UserConnection userConnection)
        {
            //var img = userConnection.image.Substring(23);
            //SaveImage("Test", img, Guid.NewGuid().ToString());

            await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.classroom);

            _connections[Context.ConnectionId] = userConnection;

            await Clients.Group(userConnection.classroom).SendAsync("ReceiveMessage", _botUser, $"{userConnection.userName} has joined {userConnection.classroom}");

            await SendUsersConnected(userConnection.userName);
        }

        public async IAsyncEnumerable<byte[]> Counter(
        byte[] img,
        [EnumeratorCancellation]
        CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                //img = img.Substring(23);
                yield return img;
                await Task.Delay(3000, cancellationToken);
            }
        }


    }
}
