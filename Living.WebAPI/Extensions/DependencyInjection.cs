using Living.Domain.Features.Users.Interfaces;
using Living.WebAPI.Services;

namespace Living.WebAPI.Extensions;

public static class DependencyInjection
{
    public static void AddWebApi(this IServiceCollection services)
    {
        services.AddScoped<IUserContext, UserContext>();
    }
}
