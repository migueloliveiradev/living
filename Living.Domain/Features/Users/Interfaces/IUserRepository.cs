using System.Security.Claims;

namespace Living.Domain.Features.Users.Interfaces;
public interface IUserRepository : IBaseRepository<User>
{
    IQueryable<Claim> GetClaims(Guid userId);
    IQueryable<Claim> GetClaimsUser(Guid userId);
    IQueryable<Claim> GetClaimsUserRoles(Guid userId);
}
