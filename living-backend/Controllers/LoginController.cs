using living_backend.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace living_backend.Controllers;
public class LoginController : Controller
{
    [HttpPost("/login")]
    public IActionResult Login([FromBody] User user)
    {
        JwtSecurityTokenHandler tokenHandler = new();
        byte[] key = Encoding.ASCII.GetBytes("testeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                  new Claim(ClaimTypes.Name, user.Username.ToString()),
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

        string tokenString = tokenHandler.WriteToken(token);

        return Json(new { token = tokenString });
    }

    [Authorize]
    [HttpGet("/test")]
    public IActionResult Test()
    {
        return Json(new { message = "Hello World", user = User.Identity!.Name });
    }
}
