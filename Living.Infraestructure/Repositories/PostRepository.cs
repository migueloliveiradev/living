using Living.Domain.Features.Posts;
using Living.Domain.Features.Posts.Interface;
using Living.Infraestructure.Context;

namespace Living.Infraestructure.Repositories;
public class PostRepository(DatabaseContext context) : BaseRepository<Post>(context), IPostRepository
{
}
