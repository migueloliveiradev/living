using Living.Domain.Features.Groups;
using Living.Domain.Features.Posts;
using Living.Domain.Features.Roles;
using Living.Domain.Features.Users.Constants;
using Microsoft.AspNetCore.Identity;

#pragma warning disable CS8765

namespace Living.Domain.Features.Users;
public class User : IdentityUser<Guid>, IEntity, ITimestamps, IValidit
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

    public bool HasSession(string refreshToken)
    {
        return UserSessions.Exists(s => s.RefreshToken == refreshToken);
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

    public IEnumerable<Notification> IsValid()
    {
        if (string.IsNullOrWhiteSpace(Name))
            yield return UserErrors.NAME_IS_REQUIRED;

        if (Name.Length < 3 || Name.Length > 100)
            yield return UserErrors.NAME_LENGTH_INVALID;

        if (string.IsNullOrWhiteSpace(UserName))
            yield return UserErrors.USERNAME_IS_REQUIRED;

        if (UserName.Length < 4 || UserName.Length > 20)
            yield return UserErrors.USERNAME_LENGTH_INVALID;

        if (string.IsNullOrWhiteSpace(Email))
            yield return UserErrors.EMAIL_IS_REQUIRED;

        if (Email.Length < 3 || Email.Length > 320)
            yield return UserErrors.EMAIL_LENGTH_INVALID;
    }
}
