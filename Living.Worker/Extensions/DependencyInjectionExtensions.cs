using Living.Infraestructure.Extensions;
using Living.Worker.Queue;

namespace Living.Worker.Extensions;
public static class DependencyInjectionExtensions
{
    public static void AddMessagingConfiguration(this IServiceCollection services)
    {
        services.AddMessaging((e) =>
            {
                e.AddConsumer<UserCreatedConsumer>();
            }
        );
    }
}
