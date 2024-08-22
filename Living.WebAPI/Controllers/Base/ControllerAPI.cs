using Living.Domain.Base;
using System.Net;

namespace Living.WebAPI.Controllers.Base;

#pragma warning disable S101

public class ControllerAPI : ControllerBase
{
    protected CancellationToken CancellationToken => HttpContext.RequestAborted;

    protected IActionResult CreateResponse(BaseResponse response, string uri = "")
    {
        return response.HttpStatusCode switch
        {
            HttpStatusCode.OK => Ok(response),
            HttpStatusCode.Created => Created(uri, response),
            HttpStatusCode.NoContent => NoContent(),
            HttpStatusCode.BadRequest => BadRequest(response),
            HttpStatusCode.UnprocessableEntity => UnprocessableEntity(response),
            HttpStatusCode.NotFound => NotFound(response),
            HttpStatusCode.Unauthorized => Unauthorized(response),
            HttpStatusCode.Forbidden => Forbid(),
            _ => Ok(response)
        };
    }
}
