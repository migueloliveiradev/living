using Living.Domain.Entity.Comments;
using Living.Domain.Entity.Posts.Enums;
using Living.Domain.Entity.Users;
using Living.Domain.Entity.Users.Models;

namespace Living.Domain.Entity.Posts.Models;
public class PostItemGet
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public Guid UserId { get; set; }
    public PostAccess Access { get; set; }
    public DateTime CreatedAt { get; set; }
    public UserBase User { get; set; }
    public IEnumerable<Comment> Comments { get; set; }
    public int LikesCount { get; set; }
    public int CommentsCount { get; set; }
}
