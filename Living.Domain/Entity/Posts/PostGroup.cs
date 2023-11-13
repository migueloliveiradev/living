using Living.Domain.Base.Interface;
using Living.Domain.Entity.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
