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

    public Group Group { get; set; }
    public User User { get; set; }
}
