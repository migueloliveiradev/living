using Living.Domain.Base.Interfaces;
using Living.Domain.Entities.Groups;
using Living.Domain.Entities.Posts;
using Living.Domain.Entities.Roles;
using Living.Domain.Entities.Users.Models;
using Microsoft.AspNetCore.Identity;

namespace Living.Domain.Entities.Users;
public class User : IdentityUser<Guid>, IEntity, ITimestamps
{
    public required string Name { get; set; }
    public override required string? UserName { get; set; }
    public string? Bio { get; set; }
    public DateOnly Birthday { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastUpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public List<Post> Posts { get; set; } = [];
    public List<PostLike> PostLikes { get; set; } = [];
    public List<UserFollow> UsersFollowers { get; set; } = [];
    public List<UserFollow> UsersFollowing { get; set; } = [];
    public List<GroupUser> GroupsUser { get; set; } = [];
    public List<Group> GroupsOwned { get; set; } = [];

    public List<IdentityUserClaim<Guid>> Claims { get; set; } = [];
    public List<IdentityUserLogin<Guid>> Logins { get; set; } = [];
    public List<IdentityUserToken<Guid>> Tokens { get; set; } = [];
    public List<UserRole> UserRoles { get; set; } = [];

    public UserAuthorItem ToAuthor()
    {
        return new()
        {
            Id = Id,
            Name = Name,
            Username = UserName!
        };
    }

    public UserProfileItem ToProfile()
    {
        return new()
        {
            Id = Id,
            Name = Name,
            Username = UserName!,
            Bio = Bio,
            Birthday = Birthday,
            CreatedAt = CreatedAt,
            DeletedAt = DeletedAt,
            FollowersCount = UsersFollowers.Count,
            FollowingCount = UsersFollowing.Count,
            PostsCount = Posts.Count
        };
    }
}
