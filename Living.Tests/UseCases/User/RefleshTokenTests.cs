using Living.Domain.Features.Users.Constants;
using Living.Tests.Extensions;

namespace Living.Tests.UseCases.User;
public class RefleshTokenTests(WebAPIFactory webAPIFactory) : SetupWebAPI(webAPIFactory)
{
    [Fact]
    public async Task RefleshToken_ShouldReflesh()
    {
        var userId = await LoginAsync();

        var cookies = GetCookies();
        var refreshToken = cookies.FirstOrDefault(p => p.Name == UserCookies.REFRESH_TOKEN);
        refreshToken.Should().NotBeNull();

        var user = await UserRepository
            .Query()
            .Include(p => p.UserSessions)
            .FirstOrDefaultAsync(p => p.Id == userId);

        user.Should().NotBeNull();
        user.UserSessions.Should().HaveCount(1);
        user.UserSessions.Should().Contain(p => p.RefreshToken == refreshToken.Value);

        var response = await Http.PostAsync("/api/auth/reflesh-token", new StringContent(""));
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var cookies2 = response.GetCookies();
        var refreshToken2 = cookies2.FirstOrDefault(p => p.Name == UserCookies.REFRESH_TOKEN);
        refreshToken2.Should().NotBeNull();

        user = await UserRepository
            .Query()
            .Include(p => p.UserSessions)
            .FirstOrDefaultAsync(p => p.Id == userId);

        user.Should().NotBeNull();
        user.UserSessions.Should().HaveCount(1);
        user.UserSessions.Should().Contain(p => p.RefreshToken == refreshToken2.Value);
        user.UserSessions.Should().NotContain(p => p.RefreshToken == refreshToken.Value);
    }

    [Fact]
    public async Task RefleshToken_ShouldValidateInvalidRefleshToken()
    {
        var response = await Http.PostAsync("/api/auth/reflesh-token", new StringContent(""));
        response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        response.GetCookies().Should().BeEmpty();

        var content = await response.Content.ReadFromJsonAsync<BaseResponse>();
        content.Should().NotBeNull();
        content.Notifications.Should().HaveCount(1);
        content.Notifications.Should().ContainNotification(UserErrors.INVALID_REFRESH_TOKEN);
    }

    [Theory]
    [InlineAutoData("")]
    [InlineAutoData("invalid")]
    public async Task RefleshToken_ShouldValidateInvalidUserId(string userId, string refreshToken)
    {
        AddCookies(
            [
                new(UserCookies.REFRESH_TOKEN, refreshToken),
                new(UserCookies.USER_ID, userId)
            ]);

        var response = await Http.PostAsync("/api/auth/reflesh-token", new StringContent(""));
        response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        response.GetCookies().Should().BeEmpty();

        var content = await response.Content.ReadFromJsonAsync<BaseResponse>();
        content.Should().NotBeNull();
        content.Notifications.Should().HaveCount(1);
        content.Notifications.Should().ContainNotification(UserErrors.INVALID_USER_ID);
    }

    [Theory, AutoData]
    public async Task RefleshToken_ShouldValidateNotFoundUser(string refreshToken, Guid userId)
    {
        AddCookies(
            [
                new(UserCookies.REFRESH_TOKEN, refreshToken),
                new(UserCookies.USER_ID, userId.ToString())
            ]);

        var response = await Http.PostAsync("/api/auth/reflesh-token", new StringContent(""));
        response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        response.GetCookies().Should().BeEmpty();

        var content = await response.Content.ReadFromJsonAsync<BaseResponse>();
        content.Should().NotBeNull();
        content.Notifications.Should().HaveCount(1);
        content.Notifications.Should().ContainNotification(UserErrors.NOT_FOUND);
    }

    [Theory, AutoData]
    public async Task RefreshToken_ShouldValidateNotHasSession(string refreshToken)
    {
        var userId = await LoginAsync();

        var user = await UserRepository
            .Query()
            .Include(p => p.UserSessions)
            .FirstOrDefaultAsync(p => p.Id == userId);

        user.Should().NotBeNull();
        user.UserSessions.Should().HaveCount(1);

        AddCookies([new(UserCookies.REFRESH_TOKEN, refreshToken)]);

        var response = await Http.PostAsync("/api/auth/reflesh-token", new StringContent(""));
        response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        response.GetCookies().Should().BeEmpty();

        var content = await response.Content.ReadFromJsonAsync<BaseResponse>();
        content.Should().NotBeNull();
        content.Notifications.Should().HaveCount(1);
        content.Notifications.Should().ContainNotification(UserErrors.INVALID_REFRESH_TOKEN);
    }
}
