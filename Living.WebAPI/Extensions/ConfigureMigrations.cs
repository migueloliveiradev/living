using FluentMigrator.Runner;
using Living.Infraestructure.Migrations;

namespace Living.WebAPI.Extensions;

public static class ConfigureMigrations
{
    public static IServiceCollection ConfigureFluentMigrator(this IServiceCollection services, IConfiguration configuration)
    {
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
