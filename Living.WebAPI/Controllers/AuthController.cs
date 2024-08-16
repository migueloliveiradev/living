using Living.Application.UseCases.Users.Login;
using Living.Application.UseCases.Users.Me;
using Living.Application.UseCases.Users.RefleshToken;
using Living.Application.UseCases.Users.Register;
using Microsoft.AspNetCore.Authorization;

namespace Living.WebAPI.Controllers;
[Route("api/auth")]
[ApiController]
public class AuthController(IMediator mediator) : ControllerAPI
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
    {
        return CreateResponse(await mediator.Send(command, CancellationToken));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {
        return CreateResponse(await mediator.Send(command, CancellationToken));
    }

    [HttpPost("reflesh-token")]
    public async Task<IActionResult> RefleshToken()
    {
        return CreateResponse(await mediator.Send(new RefleshTokenCommand(), CancellationToken));
    }

    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> Me()
    {
        return CreateResponse(await mediator.Send(new GetCurrentUserQuery(), CancellationToken));
    }
}
