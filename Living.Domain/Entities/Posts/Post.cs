using Living.Domain.Base.Interfaces;
using Living.Domain.Entities.Groups;
using Living.Domain.Entities.Users;

namespace Living.Domain.Entities.Posts;
public class Post : IEntity, ITimestamps
{
    public Guid Id { get; }
    public required string Content { get; set; }
    public required Guid AuthorId { get; set; }
    public required PostAccess Access { get; set; }
    public required PostType Type { get; set; }
    public Guid? GroupId { get; set; }
    public Guid? PostParentId { get; set; }
    public Guid? PostChildId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdatedAt { get; set; }

    public Post? PostParent { get; set; }
    public List<Post> PostsParent { get; set; } = [];
    public Post? PostChild { get; set; }
    public List<Post> PostsChildren { get; set; } = [];
    public User Author { get; set; }
    public Group? Group { get; set; }
    public List<PostLike> PostLikes { get; set; } = [];

    public void AddLike(Guid userId)
    {
        PostLikes.Add(new PostLike
        {
            PostId = Id,
            UserId = userId
        });
    }
}

public enum PostAccess
{
    Public,
    Followers,
    Group,
    Private
}

public enum PostType
{
    Post,
    Repost,
    Comment
}
