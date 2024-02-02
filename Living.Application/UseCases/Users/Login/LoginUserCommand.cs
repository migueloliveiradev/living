using Microsoft.AspNetCore.Http;

namespace Living.Application.UseCases.Users.Login;
public class LoginUserCommand : IRequest<IResult>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

    public bool UseCookies { get; set; } = true;
}
