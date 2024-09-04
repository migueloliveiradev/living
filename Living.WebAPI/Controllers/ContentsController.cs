using Living.WebAPI.Attributes;

namespace Living.WebAPI.Controllers;

[ApiController]
[Route("/api/contents")]
public class ContentsController : ControllerAPI
{
    [HttpGet("notifications")]
    [NotificationProducesResponseTypeAttribute(typeof(Dictionary<string, IEnumerable<string>>), StatusCodes.Status200OK)]
    public IActionResult GetNotifications()
    {
        return Ok();
    }
}