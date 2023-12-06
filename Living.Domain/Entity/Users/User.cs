using Living.Domain.Base.Interfaces;
using Living.Domain.Entity.Groups;
using Living.Domain.Entity.Posts;
using Microsoft.AspNetCore.Identity;

namespace Living.Domain.Entity.Users;
public class User : IdentityUser<Guid>, IEntity, ITimestamps
{
    public Guid Id { get; init; }
    public string Name { get; private set; }
    public string? PhotoFileName { get; private set; }
    public string? BannerFileName { get; private set; }
    public string? Bio { get; private set; }
    public DateOnly Birthday { get; private set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastUpdatedAt { get ;set ; }
    public DateTime? DeletedAt { get ;set ; }

    public ICollection<Post> Posts { get; set; }
    public ICollection<PostLike> PostLikes { get; set; }
    public ICollection<User> Followers { get; set; }
    public ICollection<User> Following { get; set; }
    public ICollection<GroupUser> GroupUsers { get; set; }
    public ICollection<Group> GroupsOwned { get; set; }

    public void Update(string name, string bio, DateOnly birthday)
    {
        Name = name;
        Bio = bio;
        Birthday = birthday;
    }

    public void UpdatePhoto(string photoFileName)
    {
        PhotoFileName = photoFileName;
    }

    public void UpdateBanner(string bannerFileName)
    {
        BannerFileName = bannerFileName;
    }
}
