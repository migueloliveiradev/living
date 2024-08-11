using Living.WebAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using System.Net;
using Testcontainers.PostgreSql;

namespace Living.Tests.Setup.Factory;

public class WebAPIFactory : IAsyncLifetime
{
    private readonly PostgreSqlContainer PostgreSql = new PostgreSqlBuilder()
        .WithImage("postgres:16.3")
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
                    config.AddInMemoryCollection(new Dictionary<string, string?>
                    {
                        ["ConnectionStrings:PostgresConnection"] = PostgreSql.GetConnectionString()
                    });
                });
                builder.UseEnvironment("Testing");
            });
    }


    public IServiceProvider Services => Factory.Services;

    public void AddCookies(List<Cookie> cookieCollection)
    {
        foreach (var cookie in cookieCollection)
        {
            HttpClient.DefaultRequestHeaders.Add("Cookie", cookie.ToString());
        }
    }

    public async Task InitializeAsync()
    {
        await PostgreSql.StartAsync();

        HttpClient = Factory.CreateClient();
    }

    public async Task DisposeAsync()
    {
        await PostgreSql.DisposeAsync();
    }
}
