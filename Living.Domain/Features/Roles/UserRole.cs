using Living.Domain.Features.Users;
using Microsoft.AspNetCore.Identity;

namespace Living.Domain.Entities.Roles;
public class UserRole : IdentityUserRole<Guid>
{
    public User User { get; set; }
    public Role Role { get; set; }
}
