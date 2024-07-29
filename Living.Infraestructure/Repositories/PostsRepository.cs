using Living.Domain.Entities.Posts;
using Living.Domain.Entities.Posts.Interface;
using Living.Infraestructure.Context;

namespace Living.Infraestructure.Repositories;
public class PostsRepository(DatabaseContext context) : BaseRepository<Post>(context), IPostsRepository
{
}
