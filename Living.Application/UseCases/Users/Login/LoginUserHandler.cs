using Living.Domain.Entities.Users;
using Living.Domain.Entities.Users.Constants;
using Living.Domain.Entities.Users.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Living.Application.UseCases.Users.Login;
public class LoginUserHandler(
    UserManager<User> userManager,
    IConfiguration configuration)
    : IRequestHandler<LoginUserCommand, BaseResponse<UserLoginResponse>>
{
    public async Task<BaseResponse<UserLoginResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);

        if (user is null)
            return new(UserErrors.NOT_FOUND);

        var passwordIsValid = await userManager.CheckPasswordAsync(user, request.Password);
        if (!passwordIsValid)
            return new(UserErrors.PASSWORD_INVALID);

        var token = await GenerateJWT(user);

        var response = new UserLoginResponse
        {
            AccessToken = token,
            ExpiresIn = 3600
        };

        return new(response);
    }

    private async Task<string> GenerateJWT(User user)
    {
        var claims = await GetClaims(user);

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(configuration["JWT:TOKEN"]!);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        return tokenString;
    }

    private async Task<List<Claim>> GetClaims(User user)
    {
        var claimsUser = await GetClaimsUser(user.Id);
        var claimsRoles = await GetClaimsRoles(user);

        return [
            new(UserClaimsTypes.USER_ID, user.Id.ToString()),
            ..claimsUser,
            ..claimsRoles
            ];
    }

    private async Task<List<Claim>> GetClaimsUser(Guid userId)
    {
        return await userManager.Users
            .Where(x => x.Id == userId)
            .SelectMany(x => x.UserClaims)
            .Select(x => x.ToClaim())
            .ToListAsync();
    }

    private async Task<List<Claim>> GetClaimsRoles(User user)
    {
        return await userManager
            .Users
            .Where(x => x.Id == user.Id)
            .SelectMany(x => x.UserRoles)
            .Select(x => x.Role)
            .SelectMany(x => x.RoleClaims)
            .Select(x => x.ToClaim())
            .ToListAsync();
    }
}
