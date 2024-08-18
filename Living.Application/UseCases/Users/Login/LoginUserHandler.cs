using Living.Domain.Features.Users;
using Living.Domain.Features.Users.Constants;
using Living.Domain.Services;
using Microsoft.AspNetCore.Identity;

namespace Living.Application.UseCases.Users.Login;
public class LoginUserHandler(
    IUserRepository userRepository,
    SignInManager<User> signInManager,
    IUserContext currentUser,
    ITokenService tokenService,
    IUnitOfWork unitOfWork) : Handler(unitOfWork), IRequestHandler<LoginUserCommand, BaseResponse>
{
    public async Task<BaseResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository
            .DBSet()
            .Where(u => EF.Functions.ILike(u.Email, request.Email))
            .FirstOrDefaultAsync(cancellationToken);

        if (user is null)
            return new(UserErrors.NOT_FOUND, HttpStatusCode.NotFound);

        var signInResult = await signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: false);

        if (!signInResult.Succeeded)
            return GetErrorSignIn(signInResult);

        var token = await tokenService.GenerateAccessToken(user);
        var refreshToken = await tokenService.GenerateRefreshToken(user);

        user.AddSession(refreshToken);

        currentUser.SetUserId(user.Id);
        currentUser.SetAccessToken(token);
        currentUser.SetRefreshToken(refreshToken);

        await CommitAsync(cancellationToken);

        return new();
    }

    private static BaseResponse GetErrorSignIn(SignInResult signInResult)
    {
        if (signInResult.IsLockedOut)
            return new(UserErrors.LOCKED_OUT);

        if (signInResult.IsNotAllowed)
            return new(UserErrors.NOT_ALLOWED);

        if (signInResult.RequiresTwoFactor)
            return new(UserErrors.REQUIRES_TWO_FACTOR);

        return new(UserErrors.PASSWORD_INVALID);
    }
}
