using living_backend.Models.Posts;
using living_backend.Models.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace living_backend.Models.Groups;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; }
    [ForeignKey(nameof(Owner))]
    public int OwnerId { get; set; }
    public string Description { get; set; }
    public string PhotoUrl { get; set; }
    public string BannerUrl { get; set; }
    public DateTime CreatedAt { get; set; }

    public virtual User Owner { get; set; }
    public virtual ICollection<User> Users { get; set; }
    public virtual ICollection<Post> Posts { get; set; }
}