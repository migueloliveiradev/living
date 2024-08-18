using System.Net;

namespace Living.Shared.Extensions;
public static class HttpResponseMessageExtensions
{
    private const string SET_COOKIE = "Set-Cookie";
    public static ICollection<Cookie> GetCookies(this HttpResponseMessage response)
    {
        var cookies = response.Headers.FirstOrDefault(p => p.Key == SET_COOKIE).Value;
        var cookiesContainer = new CookieContainer();

        foreach (var cookie in cookies)
            cookiesContainer.SetCookies(response.RequestMessage!.RequestUri!, cookie);

        return cookiesContainer.GetAllCookies();
    }
}
