using Living.Domain.Base;
using Microsoft.AspNetCore.Mvc;

namespace Living.WebAPI.Controllers;
public class BaseController : Controller
{
    public IActionResult CreateResponse(IBaseResponse response)
    {
        return StatusCode((int)response.StatusCode, response);
    }
}
