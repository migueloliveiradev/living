using Living.Domain.Base;
using Microsoft.AspNetCore.Diagnostics;

namespace Living.WebAPI.ExceptionsHandler;

public class ApplicationExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        var notification = new Notification("INTERNAL", "INTERNAL_SERVER_ERROR");
        var response = new BaseResponse(notification);
        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

        return true;
    }
}