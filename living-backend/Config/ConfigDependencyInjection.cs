using living_backend.Repositories.Messages;
using living_backend.Repositories.Posts;
using living_backend.Repositories.Users;
using living_backend.Service.Timeline.User;
using living_backend.Services.Users;

namespace living_backend.Config;

public static class ConfigDependencyInjection
{
    public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
        //services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<UserLoginService>();
        //services.AddScoped<INotificationRepository, NotificationRepository>();
        services.AddScoped<IUserTimeline, UserTimeline>();
        return services;
    }
}
