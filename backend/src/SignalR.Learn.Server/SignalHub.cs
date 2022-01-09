using Microsoft.AspNetCore.SignalR;

namespace SignalR.Learn.Server
{
    public class SignalHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            var connectionId = Context.ConnectionId;

            Clients.Client(connectionId).SendAsync("SendConnectionId", connectionId);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var connectionId = Context.ConnectionId;

            return base.OnDisconnectedAsync(exception);
        }
    }
}
