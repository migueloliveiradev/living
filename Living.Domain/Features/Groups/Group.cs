using Living.Domain.Features.Posts;

namespace Living.Domain.Features.Groups;
public class Group : IEntity, ITimestamps
{
    public Guid Id { get; init; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required Guid OwnerId { get; set; }


    public DateTime CreatedAt { get; }
    public DateTime LastUpdatedAt { get; set; }


    public User Owner { get; init; }
    public List<Post> Posts { get; init; } = [];
    public List<GroupUser> GroupUsers { get; init; } = [];
}
