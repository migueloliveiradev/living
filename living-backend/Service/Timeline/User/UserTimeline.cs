using living_backend.Database;
using living_backend.Models.Posts;
using Microsoft.EntityFrameworkCore;

namespace living_backend.Service.Timeline.User;

public class UserTimeline : IUserTimeline
{
    private readonly DatabaseContext context;
    public UserTimeline(DatabaseContext context)
    {
        this.context = context;
    }

    public List<Post> Get()
    {
        return context.Posts.Include(p => p.User).ToList();
    }
}
