using Living.Domain.Base.Interfaces;

namespace Living.Domain.Entities.Users;
public class UserFollow : IEntity, ITimestamp
{
    public Guid Id { get; }
    public required Guid FollowerId { get; set; }
    public required Guid FollowingId { get; set; }
    public DateTime CreatedAt { get; set; }

    public User Follower { get; set; } = null!;
    public User Following { get; set; } = null!;
}
