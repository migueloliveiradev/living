using Living.Tests.Setup.Factory;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace Living.Tests.Setup;

[CollectionDefinition("WebAPI")]
public record WebAPIFactoryCollection : ICollectionFixture<WebAPIFactory>;

[Collection("WebAPI")]
public partial class SetupWebAPI(WebAPIFactory webAPI)
{
    protected T GetService<T>() => webAPI.Services.GetService<T>()!;


    protected async Task<T> PostAsync<T>(string path, object? body = null)
    {
        var response = await webAPI.HttpClient.PostAsJsonAsync(path, body);
        var data = await response.Content.ReadFromJsonAsync<T>();
        return data!;
    }

    protected async Task<T> GetAsync<T>(string path)
    {
        var response = await webAPI.HttpClient.GetAsync(path);
        var data = await response.Content.ReadFromJsonAsync<T>();
        return data!;
    }
}