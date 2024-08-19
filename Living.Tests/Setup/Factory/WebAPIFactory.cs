using Living.WebAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
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
        .Build();

    private readonly WebApplicationFactory<Program> Factory;

    public HttpClient HttpClient { get; private set; }

    public WebAPIFactory()
    {
        Factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.UseSetting("ConnectionStrings:PostgresConnection", PostgreSql.GetConnectionString());
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
