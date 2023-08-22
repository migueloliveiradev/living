using living_backend.Models.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace living_backend.Models.Groups;

public class GroupUser
{
    public int Id { get; set; }
    [ForeignKey(nameof(Group))]
    public int GroupId { get; set; }
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public DateTime Created { get; set; }

    public virtual Group Group { get; set; }
    public virtual User User { get; set; }
}
