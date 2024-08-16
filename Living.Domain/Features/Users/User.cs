using Living.Domain.Entities.Groups;
using Living.Domain.Entities.Posts;
using Living.Domain.Entities.Roles;
using Living.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;

#pragma warning disable CS8765

namespace Living.Domain.Features.Users;
public class User : IdentityUser<Guid>, IEntity, ITimestamps
{
    public required string Name { get; set; }
    public override required string UserName { get; set; }
    public override required string Email { get; set; }
    public string? Bio { get; set; }
    public DateOnly Birthday { get; set; }


    public DateTime CreatedAt { get; }
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
    public List<UserSession> UserSessions { get; set; } = [];


    public void AddSession(string refreshToken)
    {
        UserSessions.Add(new UserSession(Id, refreshToken));
    }

    public void RemoveSession(string refreshToken)
    {
        var session = UserSessions.Find(s => s.RefreshToken == refreshToken);
        if (session is not null)
            UserSessions.Remove(session);
    }

    public void UpdateSession(string currentRefleshToken, string newRefleshToken)
    {
        var session = UserSessions.Find(s => s.RefreshToken == currentRefleshToken);
        if (session is not null)
            session.Update(newRefleshToken);
    }

    public void AddClaim(string type, string value)
    {
        UserClaims.Add(new UserClaim()
        {
            UserId = Id,
            ClaimType = type,
            ClaimValue = value
        });
    }
}
