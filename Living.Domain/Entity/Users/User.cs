using Living.Domain.Base.Interface;
using Living.Domain.Entity.Groups;
using Living.Domain.Entity.Posts;

namespace Living.Domain.Entity.Users;
public class User : IEntity, ITimestamps
{
    public Guid Id { get; init; }
    public string Username { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? PhotoUrl { get; set; }
    public string? BannerUrl { get; set; }
    public string? Bio { get; set; }
    public DateTime Birthday { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastUpdatedAt { get ;set ; }
    public DateTime? DeletedAt { get ;set ; }

    public ICollection<Post> Posts { get; set; } = new List<Post>();
    public ICollection<PostLike> PostLikes { get; set; } = new List<PostLike>();
    public ICollection<User> Followers { get; set; } = new List<User>();
    public ICollection<User> Following { get; set; } = new List<User>();
    public ICollection<GroupUser> GroupUsers { get; set; } = new List<GroupUser>();
    public ICollection<Group> GroupsOwned { get; set; } = new List<Group>();
}
