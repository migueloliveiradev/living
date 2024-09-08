using Living.Infraestructure.Extensions;
using Living.Infraestructure.Settings;
using MassTransit;
using MassTransit.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Testcontainers.PostgreSql;
using Testcontainers.RabbitMq;
using ProgramWebAPI = Living.WebAPI.Program;
using ProgramWorker = Living.Worker.Program;

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

    private readonly RabbitMqContainer RabbitMq = new RabbitMqBuilder()
        .WithImage("masstransit/rabbitmq:3.13.1")
        .WithUsername(Guid.NewGuid().ToString())
        .WithPassword(Guid.NewGuid().ToString())
        .Build();


    private WebApplicationFactory<ProgramWebAPI> WebAPI { get; }
    private WebApplicationFactory<ProgramWorker> Worker { get; }

    public HttpClient CreateHttpClient() => WebAPI.Server.CreateClient();

    public ITestHarness CreateTestHarnessWebAPI() => Worker.Services.GetTestHarness();

    public ITestHarness CreateTestHarnessWorker() => Worker.Services.GetTestHarness();

    public WebAPIFactory()
    {
        WebAPI = new WebApplicationFactory<ProgramWebAPI>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddMassTransitTestHarness(x =>
                    {
                        var connectionStrings = services.GetOptions<ConnectionStrings>();

                        x.ConfigureTeste(connectionStrings.RabbitMqConnection);

                        x.SetTestTimeouts(testInactivityTimeout: TimeSpan.FromSeconds(5));
                    });
                });

                builder.UseSetting("ConnectionStrings:PostgresConnection", PostgreSql.GetConnectionString());
                builder.UseSetting("ConnectionStrings:RabbitMqConnection", RabbitMq.GetConnectionString());
                builder.UseEnvironment("Testing");
                builder.UseTestServer();
            });

        Worker = new WebApplicationFactory<ProgramWorker>()
            .WithWebHostBuilder(builder =>
            {
                builder.Configure(_ => { });

                builder.ConfigureServices(services =>
                {
                    services.AddMassTransitTestHarness(x =>
                    {
                        var connectionStrings = services.GetOptions<ConnectionStrings>();

                        x.ConfigureTeste(connectionStrings.RabbitMqConnection);

                        x.SetTestTimeouts(testInactivityTimeout: TimeSpan.FromSeconds(5));
                    });
                });

                builder.UseSetting("ConnectionStrings:PostgresConnection", PostgreSql.GetConnectionString());
                builder.UseSetting("ConnectionStrings:RabbitMqConnection", RabbitMq.GetConnectionString());
                builder.UseEnvironment("Testing");
                builder.UseTestServer();
            });
    }


    public IServiceProvider Services => WebAPI.Services;

    public async Task InitializeAsync()
    {
        await PostgreSql.StartAsync();

        await RabbitMq.StartAsync();

        var host = Worker.Services.GetRequiredService<IHost>();

        await host.StartAsync();


    }

    public async Task DisposeAsync()
    {
        await WebAPI.DisposeAsync();

        await Worker.DisposeAsync();

        await PostgreSql.DisposeAsync();

        await RabbitMq.DisposeAsync();
    }
}
