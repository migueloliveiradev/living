using HealthChecks.NpgSql;

namespace Living.WebAPI.Extensions;

public static class HealthChecksConfiguration
{
    public static IServiceCollection ConfigureHealthChecks(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHealthChecks()
            .AddNpgSql(new NpgSqlHealthCheckOptions()
            {
                CommandText = "SELECT 1;",
                ConnectionString = configuration.GetConnectionString("PostgresSQLConnection"),
            },
            "PostgresSQL",
            Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Unhealthy,
            new string[] { "db", "sql", "sqlserver", "database" }
            );

        return services;
    }
}
