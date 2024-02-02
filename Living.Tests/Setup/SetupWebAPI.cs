using Living.Infraestructure;
using Living.WebAPI;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Living.Tests.Setup;
public class SetupWebAPI : IDisposable
{
    protected readonly HttpClient client;
    private readonly WebApplicationFactory<Program> factory;

    public SetupWebAPI()
    {
        factory = new WebAPIApplicationFactory();
        client = factory.CreateClient();

        CreateDatabase();
    }

    private void CreateDatabase()
    {
        using var context = GetService<DatabaseContext>()!;
        context.Database.EnsureCreated();
    }

    protected T GetService<T>()
    {
        return factory.Services.GetService<T>()!;
    }

    public void Dispose()
    {
        client.Dispose();
        factory.Dispose();
    }
}