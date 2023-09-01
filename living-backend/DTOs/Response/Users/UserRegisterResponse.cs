using living_backend.Shared.JSON.Converters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace living_backend.DTOs.Response.Users;

public class UserRegisterResponse
{
    public string? Token { get; set; }
    [JsonConverter(typeof(KebabCaseDictionaryConverter))]
    public Dictionary<string, object>? Errors { get; set; }
    public bool Success { get; set; }

    public UserRegisterResponse(string? token, bool success)
    {
        Token = token;
        Success = success;
    }

    public UserRegisterResponse(ModelStateDictionary model)
    {

        Errors = new SerializableError(model);
    }
}