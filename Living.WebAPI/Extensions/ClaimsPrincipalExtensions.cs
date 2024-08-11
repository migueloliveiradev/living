using Living.Domain.Entities.Users.Constants;
using Living.Shared.Extensions;
using System.Security.Claims;

namespace Living.WebAPI.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal claimsPrincipal)
    {
        var userId = claimsPrincipal.FindFirstValue(UserClaimsTokens.USER_ID);

        ArgumentException.ThrowIfNullOrWhiteSpace(userId);

        return userId.ToGuid();
    }
}
