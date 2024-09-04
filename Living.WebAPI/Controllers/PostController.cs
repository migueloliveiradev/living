using Living.Application.UseCases.Posts.Create;

namespace Living.WebAPI.Controllers;

[ApiController]
[Route("api/posts")]
public class PostController(IMediator mediator) : ControllerAPI
{
    [HttpPost]
    public async Task<IActionResult> Index([FromBody] CreatePostCommand command)
    {
        return CreateResponse(await mediator.Send(command, CancellationToken));
    }
}
