using Living.Domain.Entities.Users;
using Living.Domain.Entities.Users.Constants;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Living.Application.UseCases.Users.Login;
public class LoginUserHandler(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor) : IRequestHandler<LoginUserCommand, IResult>
{
    public async Task<IResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);

        if (user is null)
            return Results.NotFound(new BaseResponse(UserErrors.USER_NOT_FOUND));

        var passwordIsValid = await userManager.CheckPasswordAsync(user, request.Password);
        if (!passwordIsValid)
            return Results.BadRequest(new BaseResponse(UserErrors.USER_PASSWORD_INVALID));

        var claims = new List<Claim>
        {
            new(UserClaimsTypes.USER_ID, user.Id.ToString()),
        };
        
        var authenticationScheme = request.UseCookies ? IdentityConstants.ApplicationScheme : BearerTokenDefaults.AuthenticationScheme;

        var identity = new ClaimsIdentity(claims, authenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await httpContextAccessor.HttpContext!.SignInAsync(authenticationScheme, principal);

        return Results.Empty;
    }
}
