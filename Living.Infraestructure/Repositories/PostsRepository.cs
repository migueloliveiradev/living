using Living.Domain.Entity.Posts;
using Living.Domain.Entity.Posts.Interface;
using Living.Domain.Entity.Posts.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Living.Infraestructure.Repositories;
public class PostsRepository(DatabaseContext context) : BaseRepository<Post>(context), IPostsRepository
{
    public PostItemGet? Get(Guid Id)
    {
        return Query()
            .ProjectToType<PostItemGet>()

            .FirstOrDefault(p => p.Id == Id);

        return Query()
            .Select(x => new PostItemGet
            {
                Id = x.Id,
                UserId = x.UserId,
                Access = x.Access,
                Content = x.Content,
                Comments = x.Comments.Take(10),
                User = x.User,
                CommentsCount = x.Comments.Count(),
                LikesCount = x.Comments.Count(),
                CreatedAt = x.CreatedAt,
            })
            .FirstOrDefault(p => p.Id == Id);
    }
}
