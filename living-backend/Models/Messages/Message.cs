using living_backend.Models.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace living_backend.Models.Messages;

public class Message
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsRead { get; set; }
    public DateTime DeletedAt { get; set; }
    [ForeignKey(nameof(Sender))]
    public int SenderId { get; set; }
    [ForeignKey(nameof(Receiver))]
    public int ReceiverId { get; set; }

    public virtual User Sender { get; set; }
    public virtual User Receiver { get; set; }
}
