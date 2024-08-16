using Living.Domain.Features.Users.Models;

namespace Living.Domain.Features.Users.Extensions;
public static class UserQueryableExtensions
{
    public static IQueryable<UserItem> ProjectToItem(this IQueryable<User> users)
    {
        return users.Select(user => new UserItem
        {
            Id = user.Id,
            Name = user.Name,
            Username = user.UserName,
        });
    }

    public static IQueryable<UserItemDetails> ProjectToItemDetails(this IQueryable<User> users)
    {
        return users.Select(user => new UserItemDetails
        {
            Id = user.Id,
            Name = user.Name,
            Username = user.UserName,
            Bio = "",
            Birthday = user.Birthday,
            CreatedAt = user.CreatedAt,
            FollowersCount = 0,
            FollowingCount = 0,
            PostsCount = 0,
        });
    }
}
