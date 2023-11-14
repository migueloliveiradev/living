using Living.Domain.Entity.Posts;
using Living.Domain.Entity.Posts.Interface;

namespace Living.Infraestructure.Repositories;
public class PostsRepository : BaseRepository<Post>, IPostsRepository
{
    public PostsRepository(DatabaseContext context) : base(context)
    {
    }
}
