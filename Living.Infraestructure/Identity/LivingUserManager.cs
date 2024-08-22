using Living.Domain.Features.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Living.Infraestructure.Identity;
public class LivingUserManager(
    IUserStore<User> store,
    IOptions<IdentityOptions> optionsAccessor,
    IPasswordHasher<User> passwordHasher,
    IEnumerable<IUserValidator<User>> userValidators,
    IEnumerable<IPasswordValidator<User>> passwordValidators,
    ILookupNormalizer keyNormalizer,
    IdentityErrorDescriber errors,
    IServiceProvider services,
    ILogger<UserManager<User>> logger)
    : UserManager<User>(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
{
    public override Task<User?> FindByEmailAsync(string email)
    {
        return Users.FirstOrDefaultAsync(u => EF.Functions.ILike(u.Email, email), CancellationToken);
    }

    public override Task<User?> FindByNameAsync(string userName)
    {
        return Users.FirstOrDefaultAsync(u => EF.Functions.ILike(u.UserName, userName), CancellationToken);
    }
}
