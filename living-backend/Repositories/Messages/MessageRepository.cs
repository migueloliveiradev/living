using living_backend.Database;
using living_backend.Hubs;
using living_backend.Models.Messages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace living_backend.Repositories.Messages;

public class MessageRepository : IMessageRepository
{
    private readonly DatabaseContext context;
    private readonly IHubContext<ChatHub> hubContext;
    public MessageRepository(DatabaseContext context, IHubContext<ChatHub> hubContext)
    {
        this.context = context;
        this.hubContext = hubContext;
    }
    public Message? GetById(int id)
    {
        return context.Messages.Find(id);
    }

    public List<Message> GetMessages(string username, string username_me, int skip = 0, int take = 20)
    {
        return context.Messages
            .Include(m => m.Sender)
            .Include(m => m.Receiver)
            .Where(m => m.Sender.Username == username
                || m.Sender.Username == username_me
                || m.Receiver.Username == username
                || m.Receiver.Username == username_me)
            .OrderByDescending(m => m.CreatedAt)
            .Skip(skip)
            .Take(take)
            .ToList();
    }

    public Message Create(Message message)
    {
        context.Messages.Add(message);
        context.SaveChanges();
        return message;
    }

    public void ReadAllConversation(int id_user)
    {
        context.Messages.Where(m => m.SenderId == id_user).ExecuteUpdate(m => m.SetProperty(x => x.IsRead, true));
    }
}
