using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using IServiceCollection = Microsoft.Extensions.DependencyInjection.IServiceCollection;
using IServiceProvider = Microsoft.Extensions.DependencyInjection.IServiceCollection;

namespace Living.Shared.Extensions;
public static class IServiceCollectionExtensions
{
    public static TOptions GetOptions<TOptions>(this IServiceProvider services)
        where TOptions : class
    {
        using var serviceProvider = services.BuildServiceProvider();
        return serviceProvider.GetRequiredService<IOptions<TOptions>>().Value;
    }

    public static IServiceCollection AddOptionsConfiguration<T>(this IServiceCollection services, IConfiguration configuration)
        where T : class
    {
        services.AddOptions<T>()
            .Bind(configuration.GetSection(typeof(T).Name))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return services;
    }
}
