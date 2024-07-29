using Living.Domain.Base;
using System.Net;

namespace Living.WebAPI.Controllers.Base;

public class ControllerAPI : ControllerBase
{
    protected IActionResult CreateResponse(BaseResponse response, string uri = "")
    {
        return response.HttpStatusCode switch
        {
            HttpStatusCode.OK => Ok(response),
            HttpStatusCode.Created => Created(uri, response),
            HttpStatusCode.NoContent => NoContent(),
            HttpStatusCode.BadRequest => BadRequest(response),
            HttpStatusCode.NotFound => NotFound(response),
            HttpStatusCode.Unauthorized => Unauthorized(response),
            HttpStatusCode.Forbidden => Forbid(),
            _ => Ok(response)
        };
    }
}
