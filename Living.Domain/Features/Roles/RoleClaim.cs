using Microsoft.AspNetCore.Identity;

#pragma warning disable CS8765

namespace Living.Domain.Entities.Roles;
public class RoleClaim : IdentityRoleClaim<Guid>
{
    public new Guid Id { get; init; }
    public override string ClaimType { get; set; }
    public override string ClaimValue { get; set; }
    public Role Role { get; set; } = null!;
}
