using Living.Domain.Base.Interfaces;
using Living.Domain.Entity.Posts.Models;

namespace Living.Domain.Entity.Posts.Interface;
public interface IPostsRepository : IBaseRepository<Post>
{
    PostItemGet? Get(Guid Id);
}
