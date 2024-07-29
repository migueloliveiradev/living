using Living.Domain.Entities.Users.Models;

namespace Living.Domain.Entities.Users.Mapper;
public static class UserMapper
{
    public static IQueryable<UserProfileItem> ToUserProfile(this IQueryable<User> users)
    {
        return users.Select(user => new UserProfileItem
        {
            Id = user.Id,
            Name = user.Name,
            Username = user.UserName,
            Bio = user.Bio,
            Birthday = user.Birthday,
            CreatedAt = user.CreatedAt,
            FollowersCount = user.UsersFollowers.Count,
            FollowingCount = user.UsersFollowing.Count,
            PostsCount = user.Posts.Count,
        });
    }
}
