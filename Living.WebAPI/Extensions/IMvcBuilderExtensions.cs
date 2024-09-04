using Living.Domain.Base;

namespace Living.WebAPI.Extensions;

public static class IMvcBuilderExtensions
{
    public static IMvcBuilder AddInvalidModelStateConfiguration(this IMvcBuilder mvcBuilder)
    {
        mvcBuilder.ConfigureApiBehaviorOptions(options =>
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                var response = new BaseResponse(context.ModelState.Select(p =>
                {
                    var key = p.Key.ToUpperInvariant();
                    return new Notification(key, $"{key}_IS_REQUIRED");
                }));
                return new BadRequestObjectResult(response);
            };
        });

        return mvcBuilder;
    }
}