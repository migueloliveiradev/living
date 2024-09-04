namespace Living.WebAPI.Extensions;

public static class CorsExtensions
{
    private const string Policy = "LivingPolicy";

    public static IServiceCollection AddCrosConfiguration(this IServiceCollection services)
    {
        return services.AddCors(options =>
        {
            options.AddPolicy(Policy, cors => cors
                .WithOrigins("http://localhost:8080")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials());
        });
    }

    public static IApplicationBuilder UseCorsConfiguration(this IApplicationBuilder app)
    {
        return app.UseCors(Policy);
    }
}
