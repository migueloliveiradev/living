using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Living.Tests.Extensions;
public static class JsonContentExtension
{
    public static StringContent AsJsonContent(this IBaseRequest obj)
    {
        var json = JsonSerializer.Serialize(obj);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        return content;
    }

    public static async Task<T> DeserializeContent<T>(this HttpContent content)
    {
        T? result = await content.ReadFromJsonAsync<T>(CancellationToken.None);
        return result!;
    }
}
