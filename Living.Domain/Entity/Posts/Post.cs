using Living.Domain.Base.Interface;
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
}

public enum PostAccess
{
    Public,
    Followers,
    Group,
    Private
}
