using Living.Domain.Base.Interfaces;
using Living.Domain.Entities.Groups;
using Living.Domain.Entities.Users;
using Living.Domain.Features.Posts.Enums;

namespace Living.Domain.Entities.Posts;
public class Post : IEntity, ITimestamps, ISoftDelete
{
    public Guid Id { get; init; }
    public required string Content { get; set; }
    public required Guid AuthorId { get; set; }
    public required PostAccess Access { get; set; }
    public required PostType Type { get; set; }
    public Guid? GroupId { get; set; }
    public Guid? PostParentId { get; set; }
    public Guid? PostChildId { get; set; }


    public DateTime CreatedAt { get; }
    public DateTime LastUpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }


    public Post? PostParent { get; init; }
    public List<Post> PostsParent { get; init; } = [];
    public Post? PostChild { get; init; }
    public List<Post> PostsChildrens { get; init; } = [];
    public User Author { get; init; }
    public Group? Group { get; init; }
    public List<PostLike> PostLikes { get; init; } = [];

    public void AddLike(Guid userId)
    {
        PostLikes.Add(new PostLike
        {
            PostId = Id,
            UserId = userId
        });
    }
}