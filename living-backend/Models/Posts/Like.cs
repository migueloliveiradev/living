using living_backend.Models.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace living_backend.Models.Posts;

public class Like
{
    public int Id { get; set; }

    [ForeignKey(nameof(User))]
    public int UserId { get; set; }

    [ForeignKey(nameof(Post))]
    public int PostId { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User User { get; set; }
    public virtual Post Post { get; set; }
}
