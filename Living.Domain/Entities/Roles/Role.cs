using Microsoft.AspNetCore.Identity;

namespace Living.Domain.Entities.Roles;
public class Role : IdentityRole<Guid>
{
    public List<UserRole> UserRoles { get; set; } = [];
}
