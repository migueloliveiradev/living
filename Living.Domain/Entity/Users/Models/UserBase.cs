namespace Living.Domain.Entity.Users.Models;
public class UserBase
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Username { get; init; }
    public string? PhotoFileName { get; set; }
    public string? BannerFileName { get; set; }
    public string? Bio { get; set; }
    public DateOnly Birthday { get; set; }
    public DateTime CreatedAt { get; set; }
}
