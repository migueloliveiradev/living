namespace Living.Domain.Entities.Users;
public class UserFollow : IEntity, ITimestamps
{
    public Guid Id { get; init; }
    public required Guid FollowerId { get; set; }
    public required Guid FollowingId { get; set; }


    public DateTime CreatedAt { get; }
    public DateTime LastUpdatedAt { get; set; }

    public User Follower { get; init; }
    public User Following { get; init; }
}
