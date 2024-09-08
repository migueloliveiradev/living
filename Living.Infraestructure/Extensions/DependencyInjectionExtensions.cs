using Living.Domain.Features.Posts.Interface;
using Living.Domain.Features.Users.Interfaces;
using Living.Domain.Services;
using Living.Infraestructure.Context;
using Living.Infraestructure.Context.Interceptors;
using Living.Infraestructure.Repositories;
using Living.Infraestructure.Services;
using Living.Infraestructure.Settings;
using Living.Infraestructure.UnitOfWorks;
using Living.Shared.Extensions;
using Living.Shared.Handlers;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Living.Infraestructure.Extensions;

public static class DependencyInjectionExtensions
{
    public static void AddDatabase(this IServiceCollection services)
    {
        var connectionStrings = services.GetOptions<ConnectionStrings>();

        services.AddDbContext<DatabaseContext>(options =>
        {
            options.AddInterceptors(new SavingChangesInterceptor());
            options.UseNpgsql(connectionStrings.PostgresConnection);
        });
    }

    public static void AddMessaging(this IServiceCollection services)
    {
        services.AddMessaging((e) => { });
    }

    public static void AddMessaging(this IServiceCollection services, Action<IBusRegistrationConfigurator> action)
    {
        var connectionStrings = services.GetOptions<ConnectionStrings>();

        services.AddMassTransit(x =>
        {
            x.AddDelayedMessageScheduler();

            action(x);

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(new Uri(connectionStrings.RabbitMqConnection), "Living");

                cfg.UseDelayedMessageScheduler();

                cfg.ConfigureEndpoints(context);

                cfg.UseMessageRetry(retry => { retry.Interval(3, TimeSpan.FromSeconds(5)); });
            });
        });
    }

    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddRepositories();
        services.AddServices();
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
