using Microsoft.AspNetCore.Identity;

namespace Living.Domain.Features.Roles;
public class Role : IdentityRole<Guid>
{
    public List<UserRole> UserRoles { get; set; } = [];
    public List<RoleClaim> RoleClaims { get; set; } = [];
}
