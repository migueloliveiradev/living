using Living.Domain.Features.Posts.Enums;
using Living.Domain.Features.Users.Models;

namespace Living.Domain.Features.Posts.Models;
public class PostItem
{
    public required Guid Id { get; init; }
    public required string Content { get; set; }
    public required Guid AuthorId { get; set; }
    public required PostAccess Access { get; set; }
    public required int LikesCount { get; set; }
    public required int CommentsCount { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime? LastUpdatedAt { get; set; }
    public required UserAuthorItem Author { get; set; }
}
