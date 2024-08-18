using Living.WebAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Testcontainers.PostgreSql;

namespace Living.Tests.Setup.Factory;

#pragma warning disable S101

public class WebAPIFactory : IAsyncLifetime
{
    private readonly PostgreSqlContainer PostgreSql = new PostgreSqlBuilder()
        .WithImage("postgres:16.3")
        .WithDatabase("Living")
        .WithUsername(Guid.NewGuid().ToString())
        .WithPassword(Guid.NewGuid().ToString())
        .WithHostname("host.docker.internal")
        .Build();

    private readonly WebApplicationFactory<Program> Factory;

    public HttpClient HttpClient { get; private set; }

    public WebAPIFactory()
    {
        Factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureAppConfiguration((context, config) =>
                {
                    config.AddInMemoryCollection(new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase)
                    {
                        ["ConnectionStrings:PostgresConnection"] = PostgreSql.GetConnectionString(),
                    });
                });
                builder.UseEnvironment("Testing");
                builder.UseTestServer();
            });
    }


    public IServiceProvider Services => Factory.Services;

    public void AddCookies(IEnumerable<Cookie> cookieCollection)
    {
        foreach (var cookie in cookieCollection)
        {
            HttpClient.DefaultRequestHeaders.Add("Cookie", cookie.ToString());
        }
    }

    public async Task InitializeAsync()
    {
        await PostgreSql.StartAsync();

        HttpClient = Factory.Server.CreateClient();
    }

    public async Task DisposeAsync()
    {
        await PostgreSql.DisposeAsync();
    }
}
