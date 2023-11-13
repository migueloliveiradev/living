using Living.Domain.Base.Interface;
using Living.Domain.Entity.Users;

namespace Living.Domain.Entity.Groups;
public class GroupUser : IEntity, ITimestamp
{
    public Guid Id { get; init; }
    public Guid GroupId { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }

    public virtual Group Group { get; set; }
    public virtual User User { get; set; }
}
