using Living.Domain.Entities.Posts.Models;

namespace Living.Domain.Entities.Posts.Mapper;
public static class PostMapper
{
    public static IQueryable<PostItem> ToPostItem(this IQueryable<Post> posts)
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
            }
        });
    }
}
