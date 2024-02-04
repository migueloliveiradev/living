using Living.Domain.Entities.Users;
using Living.Domain.Entities.Users.Constants;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Living.Application.UseCases.Users.Login;
public class LoginUserHandler(UserManager<User> userManager) : IRequestHandler<LoginUserCommand, IResult>
{
    public async Task<IResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);

        if (user is null)
            return Results.NotFound(new BaseResponse(UserErrors.NOT_FOUND));

        var passwordIsValid = await userManager.CheckPasswordAsync(user, request.Password);
        if (!passwordIsValid)
            return Results.BadRequest(new BaseResponse(UserErrors.PASSWORD_INVALID));
        
        var authenticationScheme = request.UseCookies ? IdentityConstants.ApplicationScheme : BearerTokenDefaults.AuthenticationScheme;

        var identity = new ClaimsIdentity(GetClaims(user), authenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        return TypedResults.SignIn(principal, null, authenticationScheme);
    }

    private List<Claim> GetClaims(User user)
    {
        return [new(UserClaimsTypes.USER_ID, user.Id.ToString())];
    }
}
