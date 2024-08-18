namespace Living.Domain.Features.Posts;
public class PostLike : IEntity, ITimestamps
{
    public Guid Id { get; init; }
    public required Guid PostId { get; set; }
    public required Guid UserId { get; set; }


    public DateTime CreatedAt { get; }
    public DateTime LastUpdatedAt { get; set; }


    public Post Post { get; init; }
    public User User { get; init; }
}
