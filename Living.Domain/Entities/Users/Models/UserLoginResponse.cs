namespace Living.Domain.Entities.Users.Models;
public class UserLoginResponse
{
    public string AccessToken { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
    public string TokenType { get; set; } = null!;
    public int ExpiresIn { get; set; }
}
