using MassTransit.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Living.Tests.Setup;

#pragma warning disable S101
#pragma warning disable MA0048

[CollectionDefinition("WebAPI")]
public record WebAPIFactoryCollection : ICollectionFixture<WebAPIFactory>;

[Collection("WebAPI")]
public partial class SetupWebAPI(WebAPIFactory webAPI) : TestBase
{
    protected HttpClient Http { get; } = webAPI.CreateHttpClient();
    private ITestHarness HarnessWebApi { get; } = webAPI.CreateTestHarnessWebAPI();
    private ITestHarness HarnessWorker { get; } = webAPI.CreateTestHarnessWorker();

    protected IList<IReceivedMessage<T>> ConsumedMessages<T>()
        where T : class
    {

        return HarnessWebApi.Consumed.Select<T>().ToList();
    }

    protected IList<IPublishedMessage<T>> PublishedMessages<T>()
        where T : class
    {
        return HarnessWebApi.Published.Select<T>().ToList();
    }

    protected IReadOnlyCollection<Cookie> GetCookies() => new List<Cookie>(Http.GetCookies());
    protected void AddCookies(IEnumerable<Cookie> cookies)
    {
        foreach (var cookie in cookies)
            Http.DefaultRequestHeaders.Add("Cookie", cookie.ToString());
    }

    protected T GetService<T>()
        where T : notnull
    {
        return webAPI.Services.GetRequiredService<T>();
    }


    protected async Task<T> PostAsync<T>(string path, object? body = null)
    {
        var response = await Http.PostAsJsonAsync(path, body);

        var data = await response.Content.ReadFromJsonAsync<T>();
        return data!;
    }

    protected async Task<T> GetAsync<T>(string path)
    {
        var response = await Http.GetAsync(path);

        var data = await response.Content.ReadFromJsonAsync<T>();
        return data!;
    }
}