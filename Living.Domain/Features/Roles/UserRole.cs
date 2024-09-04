using Microsoft.AspNetCore.Identity;

namespace Living.Domain.Features.Roles;
public class UserRole : IdentityUserRole<Guid>
{
    public User User { get; set; }
    public Role Role { get; set; }
}
