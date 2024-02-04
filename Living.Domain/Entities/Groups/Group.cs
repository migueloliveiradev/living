using Living.Domain.Base.Interfaces;
using Living.Domain.Entities.Posts;
using Living.Domain.Entities.Users;

namespace Living.Domain.Entities.Groups;
public class Group : IEntity, ITimestamps
{
    public Guid Id { get; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required Guid OwnerId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdatedAt { get; set; }
    public User Owner { get; set; }
    public List<Post> Posts { get; set; } = [];
    public List<GroupUser> GroupUsers { get; set; } = [];
}
