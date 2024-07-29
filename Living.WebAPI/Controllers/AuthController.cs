using Living.Application.UseCases.Users.Login;
using Living.Application.UseCases.Users.Register;

namespace Living.WebAPI.Controllers;
[Route("api/auth")]
[ApiController]
public class AuthController(IMediator mediator) : ControllerAPI
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
    {
        return CreateResponse(await mediator.Send(command));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {
        return CreateResponse(await mediator.Send(command));
    }
}
