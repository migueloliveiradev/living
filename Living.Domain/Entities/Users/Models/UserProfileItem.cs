namespace Living.Domain.Entities.Users.Models;
public class UserProfileItem
{
    public required Guid Id { get; init; }
    public required string Name { get; set; } = "";
    public required string Username { get; set; } = "";
    public required string? Bio { get; set; }
    public required DateOnly Birthday { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required int FollowersCount { get; set; }
    public required int FollowingCount { get; set; }
    public required int PostsCount { get; set; }
}
