using System.Security.Claims;

namespace living_backend.Shared.Extensions.Mvc;

public static class ClaimsPrincipalExtensions
{
    public static int GetId(this ClaimsPrincipal principal)
    {
        ArgumentNullException.ThrowIfNull(principal, nameof(principal));

        return Convert.ToInt32(principal.FindFirstValue(ClaimTypes.NameIdentifier));
    }
    public static string GetUsername(this ClaimsPrincipal principal)
    {
        ArgumentNullException.ThrowIfNull(principal, nameof(principal));

        return principal.FindFirstValue(ClaimTypes.Name)!;
    }
}
