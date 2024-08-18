using Living.Domain.Base;
using Living.Domain.Features.Users.Constants;
using Living.Domain.Features.Users.Interfaces;
using Living.WebAPI.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Living.WebAPI.Filters;

public class HasPermissionFilter(IUserContext userContext) : IAsyncAuthorizationFilter
{
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        if (context.ActionDescriptor.EndpointMetadata?.Any(a => a is IAuthorizeData) is not true)
            return;

        var claimAuthorizeAttr = context.ActionDescriptor?.EndpointMetadata.OfType<HasPermissionAttribute>().FirstOrDefault();
        if (claimAuthorizeAttr is null)
            return;

        var hasClaims = await userContext.HasPermission(claimAuthorizeAttr.Permissions);

        if (!hasClaims)
        {
            context!.Result = new UnauthorizedObjectResult(new BaseResponse(UserErrors.NOT_AUTHORIZED));
            return;
        }

        return;
    }
}
