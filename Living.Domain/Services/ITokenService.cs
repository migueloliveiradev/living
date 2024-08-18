namespace Living.Domain.Services;
public interface ITokenService
{
    Task<string> GenerateAccessToken(User user);
    Task<string> GenerateRefreshToken(User user);
}
