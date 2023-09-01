using living_backend.Models.Messages;
using System.ComponentModel.DataAnnotations;

namespace living_backend.DTOs.Request.Messages;

public class MessageRequest
{
    [Required]
    public string Content { get; set; }
    public int ReceiverId { get; set; }

    public Message ToModel() => new()
    {
        Content = Content,
        ReceiverId = ReceiverId
    };
}
