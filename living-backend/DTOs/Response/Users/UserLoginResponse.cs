namespace living_backend.DTOs.Response.Users;

public class UserLoginResponse
{
    public string? Token { get; set; }
    public bool Success { get; set; }

    public UserLoginResponse(string? token, bool success)
    {
        Token = token;
        Success = success;
    }
}
