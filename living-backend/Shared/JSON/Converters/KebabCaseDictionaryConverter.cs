using System.Text.Json.Serialization;
using System.Text.Json;

namespace living_backend.Shared.JSON.Converters;

public class KebabCaseDictionaryConverter : JsonConverter<Dictionary<string, object>>
{
    private readonly JsonNamingPolicy _jsonNamingPolicy = JsonNamingPolicy.SnakeCaseLower;

    public override Dictionary<string, object> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, Dictionary<string, object> value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        foreach (var kvp in value)
        {
            string propertyName = _jsonNamingPolicy.ConvertName(kvp.Key);
            writer.WritePropertyName(propertyName);
            JsonSerializer.Serialize(writer, kvp.Value, options);
        }

        writer.WriteEndObject();
    }
}