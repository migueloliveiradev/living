using living_backend.Models.Groups;
using living_backend.Models.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace living_backend.Models.Posts;

public class Post
{
    public int Id { get; set; }
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    [ForeignKey(nameof(Group))]
    public int? GroupId { get; set; }

    public string Content { get; set; }
    public int LikesCount { get; }
    public Access Access { get; set; }
    public DateTime CreatedAt { get; set; }

    public virtual User User { get; set; }
    public virtual Group Group { get; set; }
    public virtual ICollection<Attachment> Attachments { get; set; }
    public virtual ICollection<Like> Likes { get; set; }
}

public enum Access
{
    Public,
    Followers,
    Group,
    Private
}
