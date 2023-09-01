using living_backend.Models.Groups;
using living_backend.Models.Posts;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace living_backend.Models.Users;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    [JsonIgnore]
    public string Password { get; set; }
    public string? PhotoUrl { get; set; }
    public string? BannerUrl { get; set; }
    public string? Bio { get; set; }
    public int FollowersCount { get; set; }
    public int FollowingCount { get; set; }
    public DateTime Birthday { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    [DefaultValue(Role.User)]
    public Role Role { get; set; }
    public virtual ICollection<Post> Posts { get; set; }
    public virtual ICollection<Like> Likes { get; set; }
    public virtual ICollection<User> Followers { get; set; }
    public virtual ICollection<User> Following { get; set; }
    public virtual ICollection<Group> Groups { get; set; }
    public virtual ICollection<Group> GroupsOwned { get; set; }
}

public enum Role
{
    User,
    Moderator,
    Admin,
}