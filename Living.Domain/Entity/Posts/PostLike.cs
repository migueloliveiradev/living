using Living.Domain.Base.Interfaces;
using Living.Domain.Entity.Users;

namespace Living.Domain.Entity.Posts;
public class PostLike : IEntity, ITimestamp
{
    public PostLike(Guid postId, Guid userId)
    {
        Id = Guid.NewGuid();
        PostId = postId;
        UserId = userId;
    }

    public Guid Id { get; init; }
    public Guid PostId { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }

    public virtual Post Post { get; set; }
    public virtual User User { get; set; }
}
