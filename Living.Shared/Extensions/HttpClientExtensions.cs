using System.Net;

namespace Living.Shared.Extensions;

public static class HttpClientExtensions
{
    public static ICollection<Cookie> GetCookies(this HttpClient client)
    {
        var cookies = client.DefaultRequestHeaders.GetValues("Cookie");
        var cookiesContainer = new CookieContainer();

        foreach (var cookie in cookies)
            cookiesContainer.SetCookies(client.BaseAddress!, cookie);

        return cookiesContainer.GetAllCookies();
    }
}
