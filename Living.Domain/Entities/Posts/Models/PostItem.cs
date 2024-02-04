using Living.Domain.Entities.Posts;
using Living.Domain.Entities.Users.Models;

namespace Living.Domain.Entities.Posts.Models;
public class PostItem
{
    public required Guid Id { get; set; }
    public required string Content { get; set; }
    public required Guid AuthorId { get; set; }
    public required PostAccess Access { get; set; }
    public required int LikesCount { get; set; }
    public required int CommentsCount { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime? LastUpdatedAt { get; set; }
    public required DateTime? DeletedAt { get; set; }
    public required UserAuthorItem Author { get; set; }
}
