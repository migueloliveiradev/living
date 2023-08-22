
using System.ComponentModel.DataAnnotations.Schema;

namespace living_backend.Models.Posts;

public class Attachment
{
    public int Id { get; set; }
    public string Url { get; set; }
    public AttachmentType Type { get; set; }
    [ForeignKey(nameof(Post))]
    public int PostId { get; set; }
    public virtual Post Post { get; set; }
}
public enum AttachmentType
{
    Image,
    Video,
    File
}
