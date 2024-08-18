using Living.Domain.Features.Users;
using Living.Domain.Features.Users.Interfaces;
using Living.Infraestructure.Context;
using System.Security.Claims;

namespace Living.Infraestructure.Repositories;
public class UserRepository(DatabaseContext context) : BaseRepository<User>(context), IUserRepository
{
    public IQueryable<Claim> GetClaims(Guid userId)
    {
        return GetClaimsUser(userId)
            .Union(GetClaimsUserRoles(userId));
    }

    public IQueryable<Claim> GetClaimsUser(Guid userId)
    {
        return Query()
            .Where(x => x.Id == userId)
            .SelectMany(x => x.UserClaims)
            .Select(x => x.ToClaim());
    }

    public IQueryable<Claim> GetClaimsUserRoles(Guid userId)
    {
        return Query()
            .Where(x => x.Id == userId)
            .SelectMany(x => x.UserRoles)
            .Select(x => x.Role)
            .SelectMany(x => x.RoleClaims)
            .Select(x => x.ToClaim());
    }
}
