using FluentValidation;
using Living.Domain.Base;
using Microsoft.AspNetCore.Diagnostics;

namespace Living.WebAPI.ExceptionsHandler;

public class FluentValidationExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is ValidationException validation)
        {
            var notifications = validation.Errors.Select(e => new Notification(e.PropertyName.ToUpper(), e.ErrorCode));

            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            await httpContext.Response.WriteAsJsonAsync(new BaseResponse(notifications.DistinctBy(p => p.Code)), cancellationToken);

            return true;
        }

        return false;
    }
}