using MeetingServer.DTOs;
using Microsoft.AspNetCore.SignalR;

namespace MeetingServer.SignalR
{
    public class ChatHub : Hub
    {
        //public async Task SendVideo(byte[] videoData)
        //{
        //    await Clients.All.SendAsync("ReceiveVideo", videoData);
        //}

        public async Task MoveViewFromServer(float newX, float newY)
        {
            await Clients.Others.SendAsync("ReceiveNewPosition", newX, newY);
        }

    }
}
