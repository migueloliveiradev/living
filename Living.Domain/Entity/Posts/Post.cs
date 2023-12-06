using Living.Domain.Base.Interfaces;
using Living.Domain.Entity.Comments;
using Living.Domain.Entity.Posts.Enums;
using Living.Domain.Entity.Users;

namespace Living.Domain.Entity.Posts;
public class Post : IEntity, ITimestamps
{
    public Guid Id { get; init; }
    public string Content { get; set; }
    public Guid UserId { get; set; }
    public PostAccess Access { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastUpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public virtual User User { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
    public virtual ICollection<PostLike> PostLike { get; set; }

    public void AddComment(Guid UserId, string content)
    {
        Comments.Add(new Comment(Id, UserId, content));
    }

    public void AddLike(Guid userId)
    {
        PostLike.Add(new PostLike(Id, userId));
    }
}