using living_backend.Models.Posts;

namespace living_backend.Service.Timeline.User;

public interface IUserTimeline
{
    List<Post> Get();
}
