using Living.Domain.Features.Users.Constants;
using Living.Domain.Features.Users.Models;
using Living.Tests.Extensions;

namespace Living.Tests.UseCases.User;
public class MeUserTests(WebAPIFactory webAPIFactory) : SetupWebAPI(webAPIFactory)
{
    [Fact]
    public async Task GetMe_ShouldReturn()
    {
        var userId = await LoginAsync();

        var user = await UserRepository.Query()
            .FirstOrDefaultAsync(x => x.Id == userId);

        user.Should().NotBeNull();

        var me = await GetAsync<BaseResponse<UserItemDetails>>("/api/auth/me");
        me.Should().NotBeNull();
        me.HttpStatusCode.Should().Be(HttpStatusCode.OK);
        me.Data.Should().BeEquivalentTo(new UserItemDetails
        {
            Id = userId,
            Name = user.Name,
            Username = user.UserName,
            Bio = user.Bio,
            Birthday = user.Birthday,
            CreatedAt = me.Data.CreatedAt,
            FollowersCount = 0,
            FollowingCount = 0,
            PostsCount = 0
        });
    }

    [Fact]
    public async Task GetMe_ShouldReturnUnauthorized()
    {
        var me = await GetAsync<BaseResponse<UserItemDetails>>("/api/auth/me");
        me.Should().NotBeNull();
        me.HttpStatusCode.Should().Be(HttpStatusCode.Unauthorized);
        me.Notifications.Should().ContainNotification(UserErrors.NOT_AUTHORIZED);
        me.Data.Should().BeNull();
    }
}
