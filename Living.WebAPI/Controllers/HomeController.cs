using Living.Application.UseCases.Posts.Create;
using Microsoft.AspNetCore.Mvc;

namespace Living.WebAPI.Controllers;

[ApiController]
public class HomeController(IMediator mediator) : Controller
{
    [HttpGet("/post")]
    public IActionResult Index()
    {

        return Ok(mediator.Send(new CreatePostCommand()));
    }
}
