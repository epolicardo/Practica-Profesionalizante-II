using Microsoft.AspNetCore.SignalR;

namespace OrderNow.BlazorServer.Hubs
{
    public class ChatHub : Hub
    {
        public Task SendMessage(string user, string message)
        {
            return Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public Task OrderPlaced(Orders order)
        {
            return Clients.All.SendAsync("NewOrder", order);
        }
    }
}