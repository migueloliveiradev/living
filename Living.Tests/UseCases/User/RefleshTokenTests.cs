using Living.Domain.Features.Users.Constants;

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
}
