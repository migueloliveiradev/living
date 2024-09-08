using Living.Infraestructure.Settings;
using Living.Shared.Extensions;

namespace Living.Worker.Extensions;
public static class OptionsExtensions
{
    public static IServiceCollection AddOptionsConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptionsConfiguration<ConnectionStrings>(configuration);

        return services;
    }
}