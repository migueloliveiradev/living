using Living.Domain.Entities.Posts;
using Living.Domain.Entities.Posts.Interface;
using Living.Infraestructure.Context;

namespace Living.Infraestructure.Repositories;
public class PostsRepository : BaseRepository<Post>, IPostsRepository
{
    public PostsRepository(DatabaseContext context) : base(context)
    {
    }
}
