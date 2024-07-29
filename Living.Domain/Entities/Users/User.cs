using Living.Domain.Base.Interfaces;
using Living.Domain.Entities.Groups;
using Living.Domain.Entities.Posts;
using Living.Domain.Entities.Roles;
using Microsoft.AspNetCore.Identity;

#pragma warning disable CS8765

namespace Living.Domain.Entities.Users;
public class User : IdentityUser<Guid>, IEntity, ITimestamps
{
    public required string Name { get; set; }
    public override required string UserName { get; set; }
    public override required string Email { get; set; }
    public string? Bio { get; set; }
    public DateOnly Birthday { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdatedAt { get; set; }

    public List<Post> Posts { get; set; } = [];
    public List<PostLike> PostLikes { get; set; } = [];

    public List<UserFollow> UsersFollowers { get; set; } = [];
    public List<UserFollow> UsersFollowing { get; set; } = [];

    public List<GroupUser> GroupsUser { get; set; } = [];
    public List<Group> GroupsOwned { get; set; } = [];

    public List<UserRole> UserRoles { get; set; } = [];
    public List<UserClaim> UserClaims { get; set; } = [];
    public List<UserLogin> UserLogins { get; set; } = [];
    public List<UserToken> UserTokens { get; set; } = [];
}
