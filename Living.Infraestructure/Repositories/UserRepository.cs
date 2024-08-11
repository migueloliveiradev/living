using Living.Domain.Entities.Users;
using Living.Domain.Entities.Users.Constants;
using Living.Domain.Entities.Users.Interfaces;
using Living.Infraestructure.Context;
using System.Security.Claims;

namespace Living.Infraestructure.Repositories;
public class UserRepository(DatabaseContext context) : BaseRepository<User>(context), IUserRepository
{
    public async Task<List<Claim>> GetClaims(Guid userId)
    {
        var claimsUser = await GetClaimsUser(userId);
        var claimsRoles = await GetClaimsUserRoles(userId);

        return [
            new(UserClaimsTokens.USER_ID, userId.ToString()),
            ..claimsUser,
            ..claimsRoles
            ];
    }

    public Task<List<Claim>> GetClaimsUser(Guid userId)
    {
        return Query()
            .Where(x => x.Id == userId)
            .SelectMany(x => x.UserClaims)
            .Select(x => x.ToClaim())
            .ToListAsync();
    }

    public Task<List<Claim>> GetClaimsUserRoles(Guid userId)
    {
        return Query()
            .Where(x => x.Id == userId)
            .SelectMany(x => x.UserRoles)
            .Select(x => x.Role)
            .SelectMany(x => x.RoleClaims)
            .Select(x => x.ToClaim())
            .ToListAsync();
    }
}
