namespace Living.Domain.Features.Users;
public class UserSession(Guid userId, string refreshToken) : IEntity, ITimestamps
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; } = userId;
    public string RefreshToken { get; set; } = refreshToken;
    public DateTime CreatedAt { get; }
    public DateTime LastUpdatedAt { get; }

    public User User { get; set; }


    public void Update(string refleshToken)
    {
        RefreshToken = refleshToken;
    }
}
