using Microsoft.AspNetCore.Identity;

namespace Living.Domain.Features.Users;
public class UserToken : IdentityUserToken<Guid>
{
    public Guid Id { get; init; }
    public User User { get; set; }
}
