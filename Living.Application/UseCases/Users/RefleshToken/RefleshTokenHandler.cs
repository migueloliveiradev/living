using Living.Domain.Entities.Users.Constants;
using Living.Domain.Features.Users.Constants;
using Living.Domain.Services;
using Living.Shared.Extensions;

namespace Living.Application.UseCases.Users.RefleshToken;
public class RefleshTokenHandler(
    IUserContext context,
    ITokenService tokenService,
    IUserRepository userRepository,
    IUnitOfWork unitOfWork) : Handler(unitOfWork), IRequestHandler<RefleshTokenCommand, BaseResponse>
{
    public async Task<BaseResponse> Handle(RefleshTokenCommand request, CancellationToken cancellationToken)
    {
        if (!context.TryGetCookie(UserCookies.REFRESH_TOKEN, out var currentRefreshToken))
            return new(UserErrors.INVALID_REFRESH_TOKEN);

        if (!context.TryGetCookie(UserCookies.USER_ID, out var userId))
            return new(UserErrors.INVALID_USER_ID);

        var user = await userRepository
            .DBSet()
            .Where(u => u.Id == userId.ToGuid())
            .Include(u => u.UserSessions)
            .FirstOrDefaultAsync(cancellationToken);

        if (user is null)
            return new(UserErrors.NOT_FOUND);

        var token = await tokenService.GenerateAccessToken(user);
        var refreshToken = await tokenService.GenerateRefreshToken(user);

        user.UpdateSession(currentRefreshToken, refreshToken);

        context.SetAccessToken(token);
        context.SetRefreshToken(refreshToken);

        await CommitAsync(cancellationToken);

        return new();
    }
}
