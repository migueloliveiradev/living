using FluentMigrator.Runner.Processors;
using FluentMigrator.Runner;
using Living.Infraestructure.Migrations.Users;
using System.Text.Json;

namespace Living.WebAPI.Extensions;

public static class Configurations
{
    public static IMvcBuilder ConfigureJsonPolicy(this IMvcBuilder mvc)
    {
        mvc.AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
            options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.SnakeCaseLower;
        });

        return mvc;
    }

    public static IServiceCollection AddFluentMigrator(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ProcessorOptions>();

        services.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddPostgres()
                    .WithGlobalConnectionString(configuration.GetConnectionString("PostgresSQLConnection"))
                    .ScanIn(typeof(CreateTableUsers).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);

        return services;
    }

    public static void UpdateDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

        runner.MigrateUp();
    }
}
