using Living.Application.UseCases.Posts.Create;
using Microsoft.AspNetCore.Mvc;

namespace Living.WebAPI.Controllers;

[ApiController]
[Route("api/posts")]
public class PostController(IMediator mediator) : Controller
{
    [HttpPost]
    public async Task<IActionResult> Index([FromBody] CreatePostCommand command)
    {

        return Ok(await mediator.Send(command));
    }
}
