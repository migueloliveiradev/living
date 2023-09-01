using living_backend.Models.Messages;

namespace living_backend.Repositories.Messages;

public interface IMessageRepository
{
    Message? GetById(int id);
    List<Message> GetMessages(string username, string username_me, int skip = 0, int take = 20);
    Message Create(Message message);
    void ReadAllConversation(int id_user);
}
