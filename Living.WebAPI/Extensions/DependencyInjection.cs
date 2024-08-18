using Living.Domain.Features.Posts.Interface;
using Living.Domain.Features.Users.Interfaces;
using Living.Domain.Services;
using Living.Infraestructure.Repositories;
using Living.Infraestructure.Services;
using Living.Infraestructure.UnitOfWorks;
using Living.Shared.Handlers;
using Living.WebAPI.Services;

namespace Living.WebAPI.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserContext, UserContext>();

        services.AddRepositories();
        services.AddServices();

        return services;
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
    }
}
