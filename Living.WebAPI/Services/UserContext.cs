using Living.Domain.Features.Users.Constants;
using Living.Domain.Features.Users.Interfaces;
using Living.Infraestructure.Settings;
using Living.WebAPI.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;

namespace Living.WebAPI.Services;

#pragma warning disable S3928

public class UserContext(
    IHttpContextAccessor httpContextAccessor,
    IUserRepository userRepository,
    IOptions<JwtSettings> options) : IUserContext
{
    private readonly JwtSettings settings = options.Value;
    private HttpContext HttpContext => httpContextAccessor.HttpContext ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    private IIdentity Identity => HttpContext.User.Identity ?? throw new ArgumentNullException(nameof(HttpContext.User.Identity));


    public Guid UserId => HttpContext.User.GetUserId();
    public bool IsAuthenticated => Identity.IsAuthenticated;

    public void SetAccessToken(string accessToken)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None,
            Expires = DateTimeOffset.UtcNow.AddMinutes(settings.AccessTokenExpireInMinutes),
        };
        HttpContext.Response.Cookies.Append(UserCookies.ACCESS_TOKEN, accessToken, cookieOptions);
    }

    public void SetRefreshToken(string refreshToken)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None,
            Expires = DateTimeOffset.UtcNow.AddMonths(settings.RefreshTokenExpireInMonth),
        };

        HttpContext.Response.Cookies.Append(UserCookies.REFRESH_TOKEN, refreshToken, cookieOptions);
    }

    public void SetUserId(Guid userId)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None,
            Expires = DateTimeOffset.UtcNow.AddMonths(settings.RefreshTokenExpireInMonth),
        };

        HttpContext.Response.Cookies.Append(UserCookies.USER_ID, userId.ToString(), cookieOptions);
    }

    public bool TryGetCookie(string key, [NotNullWhen(true)] out string? value)
    {
        return HttpContext.Request.Cookies.TryGetValue(key, out value);
    }

    public async Task<bool> HasPermission(string permission)
    {
        return await userRepository
             .GetClaims(UserId)
             .Where(x => x.Type == UserClaimsTokens.PERMISSION)
             .AnyAsync(x => x.Value == permission, HttpContext.RequestAborted);
    }

    public Task<List<string>> GetPermissions()
    {
        return userRepository
            .GetClaims(UserId)
            .Where(x => x.Type == UserClaimsTokens.PERMISSION)
            .Select(x => x.Value)
            .ToListAsync(HttpContext.RequestAborted);
    }
}
