using System.ComponentModel.DataAnnotations.Schema;

namespace living_backend.Models.Users;

public class Notification
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsRead { get; set; }
    public NotificationType Type { get; set; }
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public User User { get; set; }
}

public enum NotificationType
{
    Follow,
    Like,
    Comment,
    Mention,
    Message
}
