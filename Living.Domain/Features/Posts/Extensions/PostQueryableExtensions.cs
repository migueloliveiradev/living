using Living.Domain.Features.Posts.Models;

namespace Living.Domain.Features.Posts.Extensions;
public static class PostQueryableExtensions
{
    public static IQueryable<PostItem> ProjectToItem(this IQueryable<Post> posts)
    {
        return posts.Select(post => new PostItem
        {
            Id = post.Id,
            Content = post.Content,
            AuthorId = post.AuthorId,
            Access = post.Access,
            LikesCount = post.PostLikes.Count,
            CommentsCount = post.PostsChildrens.Count,
            CreatedAt = post.CreatedAt,
            LastUpdatedAt = post.LastUpdatedAt,
            Author = new()
            {
                Id = post.Author.Id,
                Name = post.Author.Name,
                Username = post.Author.UserName
            },
        });
    }
}
