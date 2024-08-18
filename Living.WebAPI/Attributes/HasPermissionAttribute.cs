using Living.Domain.Features.Users.Constants;
using Microsoft.AspNetCore.Authorization;

namespace Living.WebAPI.Attributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = false)]
public class HasPermissionAttribute : AuthorizeAttribute
{
    public string Permissions { get; private set; }

    public HasPermissionAttribute(string permission)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(permission);

        if (!UserClaims.All.Contains(permission, StringComparer.Ordinal))
            throw new ArgumentException($"Invalid permission: {permission}");

        Permissions = permission;
    }
}
