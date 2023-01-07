using Microsoft.AspNetCore.SignalR;

namespace OrderNow.Blazor.Hubs
{
    public class BusinessHub : Hub
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