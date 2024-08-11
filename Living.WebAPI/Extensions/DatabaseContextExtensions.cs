using FluentMigrator.Runner;
using Living.Infraestructure.Context;
using Living.Infraestructure.Context.Interceptors;
using Living.Infraestructure.Migrations;
using Living.Infraestructure.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Living.WebAPI.Extensions;

public static class DatabaseContextExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        using var serviceProvider = services.BuildServiceProvider();
        var connectionStrings = serviceProvider.GetRequiredService<IOptions<ConnectionStrings>>().Value;

        services.AddDbContext<DatabaseContext>(options =>
        {
            options.AddInterceptors(new SavingChangesInterceptor());
            options.UseNpgsql(connectionStrings.PostgresConnection);
        });

        return services.AddFluentMigrator(connectionStrings.PostgresConnection);
    }

    private static IServiceCollection AddFluentMigrator(this IServiceCollection services, string connectionString)
    {
        services.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddPostgres()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(AddIdentity).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole());

        return services;
    }


    public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

        runner.MigrateUp();

        return app;
    }
}
