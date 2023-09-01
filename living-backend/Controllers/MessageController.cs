using living_backend.DTOs.Request.Messages;
using living_backend.Models.Messages;
using living_backend.Repositories.Messages;
using living_backend.Shared.Extensions.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace living_backend.Controllers;
public class MessageController : ControllerBase
{
    private readonly IMessageRepository messageRepository;
    public MessageController(IMessageRepository messageRepository)
    {
        this.messageRepository = messageRepository;
    }
    [HttpGet("/messages/{username}")]
    public IActionResult GetMessages(string username, int skip, int take)
    {
        Task.Delay(2000).Wait();
        string username_me = User.GetUsername();
        List<Message> messages = messageRepository.GetMessages(username, username_me, skip, take);
        return Ok(messages);
    }
    [HttpPost("/messages/send")]
    public IActionResult SendMessage(MessageRequest messageRequest)
    {
        if(!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }
        Message message = messageRequest.ToModel();
        message.SenderId = User.GetId();
        message.CreatedAt = DateTime.Now;
        message.IsRead = false;
        messageRepository.Create(message);
        return Ok(message);
    }
}
