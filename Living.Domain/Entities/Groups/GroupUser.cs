using Living.Domain.Base.Interfaces;
using Living.Domain.Entities.Users;

namespace Living.Domain.Entities.Groups;
public class GroupUser : IEntity, ITimestamp
{
    public Guid Id { get; init; }
    public Guid GroupId { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }

    public virtual Group Group { get; set; }
    public virtual User User { get; set; }
}
