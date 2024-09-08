using FluentMigrator.Runner;
using Living.Infraestructure.Migrations;
using Living.Infraestructure.Settings;
using Living.Shared.Extensions;

namespace Living.WebAPI.Extensions;

public static class DatabaseContextExtensions
{
    public static void AddMigrations(this IServiceCollection services)
    {
        var connectionStrings = services.GetOptions<ConnectionStrings>();

        services.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddPostgres()
                    .WithGlobalConnectionString(connectionStrings.PostgresConnection)
                    .ScanIn(typeof(AddIdentity).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole());
    }


    public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

        runner.MigrateUp();

        return app;
    }
}
