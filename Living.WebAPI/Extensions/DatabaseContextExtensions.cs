using FluentMigrator.Runner;
using Living.Infraestructure.Context;
using Living.Infraestructure.Context.Interceptors;
using Living.Infraestructure.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Living.WebAPI.Extensions;

public static class DatabaseContextExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PostgresConnection")!;

        services.AddDbContext<DatabaseContext>(options =>
        {
            options.AddInterceptors(new TimestampsInterceptor());
            options.UseNpgsql(connectionString);
        });

        return services.AddFluentMigrator(connectionString);
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
