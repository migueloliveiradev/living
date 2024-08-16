using System.Diagnostics.CodeAnalysis;

namespace Living.Domain.Features.Users.Interfaces;
public interface IUserContext
{
    Guid UserId { get; }
    bool IsAuthenticated { get; }
    void SetAccessToken(string accessToken);
    void SetRefreshToken(string refreshToken);
    bool TryGetCookie(string key, [NotNullWhen(true)] out string? value);
    void SetUserId(Guid userId);
}
