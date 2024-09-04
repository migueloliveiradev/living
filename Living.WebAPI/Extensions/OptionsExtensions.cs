using Living.Infraestructure.Settings;

namespace Living.WebAPI.Extensions;

public static class OptionsExtensions
{
    public static IServiceCollection AddOptionsConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureOptions<JwtSettings>(configuration);
        services.ConfigureOptions<ConnectionStrings>(configuration);

        return services;
    }

    private static IServiceCollection ConfigureOptions<T>(this IServiceCollection services, IConfiguration configuration)
        where T : class
    {
        services.AddOptions<T>()
            .Bind(configuration.GetSection(typeof(T).Name))
            .ValidateDataAnnotations();

        return services;
    }
}
