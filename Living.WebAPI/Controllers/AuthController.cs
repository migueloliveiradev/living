using Living.Application.UseCases.Users.Login;
using Living.Application.UseCases.Users.Register;
using Microsoft.AspNetCore.Mvc;

namespace Living.WebAPI.Controllers;
[Route("api/auth")]
[ApiController]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IResult> Register([FromBody] RegisterUserCommand command)
    {
        return await mediator.Send(command);
    }

    [HttpPost("login")]
    public async Task<IResult> Login([FromBody] LoginUserCommand command)
    {
        return await mediator.Send(command);
    }
}
