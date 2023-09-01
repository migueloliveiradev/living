using living_backend.Models.Posts;
using living_backend.Service.Timeline.User;
using Microsoft.AspNetCore.Mvc;

namespace living_backend.Controllers.Home;
[Route("/timeline")]
public class TimelineController : ControllerBase
{
    private readonly IUserTimeline userTimeline;
    public TimelineController(IUserTimeline userTimeline)
    {
        this.userTimeline = userTimeline;
    }

    [HttpGet("get")]
    public IActionResult Get()
    {
        List<Post> posts = userTimeline.Get();
        return Ok(posts);
    }
}
