using living_backend.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace living_backend.Services;

public class NotificationService
{
    private readonly IHubContext<NotificationHub> hubContext;
    public NotificationService(IHubContext<NotificationHub> hubContext)
    {
        this.hubContext = hubContext;
    }
    public async Task SendNotification(string user, string message)
    {
        await hubContext.Clients.User(user).SendAsync("ReceiveMessage", user, message);
    }
}
