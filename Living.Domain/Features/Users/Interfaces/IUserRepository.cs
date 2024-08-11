using Living.Domain.Base.Interfaces;
using System.Security.Claims;

namespace Living.Domain.Entities.Users.Interfaces;
public interface IUserRepository : IBaseRepository<User>
{
    Task<List<Claim>> GetClaims(Guid userId);
    Task<List<Claim>> GetClaimsUser(Guid userId);
    Task<List<Claim>> GetClaimsUserRoles(Guid userId);
}
