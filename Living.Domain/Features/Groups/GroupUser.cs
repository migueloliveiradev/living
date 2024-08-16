using Living.Domain.Base.Interfaces;
using Living.Domain.Features.Users;

namespace Living.Domain.Entities.Groups;
public class GroupUser : IEntity, ITimestamps
{
    public Guid Id { get; init; }
    public Guid GroupId { get; set; }
    public Guid UserId { get; set; }


    public DateTime CreatedAt { get; }
    public DateTime LastUpdatedAt { get; set; }


    public Group Group { get; init; }
    public User User { get; init; }
}
