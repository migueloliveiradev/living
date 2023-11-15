using Living.Domain.Base.Interfaces;
using Living.Domain.Entity.Groups;

namespace Living.Domain.Entity.Posts;
public class PostGroup : IEntity, ITimestamp
{
    public Guid Id { get; init; }
    public Guid PostId { get; set; }
    public Guid GroupId { get; set; }
    public DateTime CreatedAt { get; set; }

    public virtual Post Post { get; set; }
    public virtual Group Group { get; set; }
}
