using Living.Domain.Features.Users;
using Living.Domain.Features.Users.Interfaces;
using Living.Domain.Services;
using Living.Infraestructure.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Living.Infraestructure.Services;
public class TokenService(IOptions<JwtSettings> options, IUserRepository userRepository) : ITokenService
{
    private readonly JwtSettings configuration = options.Value;

    public async Task<string> GenerateAccessToken(User user)
    {
        var claims = await userRepository.GetClaims(user.Id).ToListAsync();

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(configuration.Secret);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(configuration.AccessTokenExpireInMinutes),
            Audience = configuration.Audience,
            Issuer = configuration.Issuer,
            SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        return tokenString;
    }

    public Task<string> GenerateRefreshToken(User user)
    {
        var token = Guid.NewGuid().ToString();

        return Task.FromResult(token);
    }
}
