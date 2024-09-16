using Living.Domain.Base;
using Living.Domain.Features.Posts.Models;

namespace Living.WebAPI.Controllers;

[ApiController]
[Route("api/feed")]
[Authorize]
public class FeedController : ControllerAPI
{
    [HttpGet]
    [ProducesResponseType<Paginated<PostItem>>(200)]
    public async Task<IActionResult> Index()
    {
        throw new NotImplementedException();
    }
}
