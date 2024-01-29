using Living.Domain.Base.Interfaces;
using Living.Domain.Entities.Users;

namespace Living.Domain.Entities.Posts;
public class PostLike : IEntity, ITimestamp
{
    public Guid Id { get; }
    public required Guid PostId { get; set; }
    public required Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }

    public Post Post { get; set; }
    public User User { get; set; }
}
