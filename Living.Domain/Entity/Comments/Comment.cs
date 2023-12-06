using Living.Domain.Base.Interfaces;
using Living.Domain.Entity.Posts;
using Living.Domain.Entity.Users;

namespace Living.Domain.Entity.Comments;
public class Comment : IEntity, ITimestamps
{
    public Comment(Guid postId, Guid userId, string content)
    {
        Id = Guid.NewGuid();
        PostId = postId;
        UserId = userId;
        Content = content;
    }

    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public Guid PostId { get; init; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastUpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public User User { get; set; }
    public Post Post { get; set; }
    public ICollection<Comment> Comments { get; init; }
}
