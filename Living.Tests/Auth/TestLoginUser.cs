using Living.Application.UseCases.Users.Login;
using Living.Domain.Entities.Users.Constants;
using Living.Domain.Entities.Users.Models;
using Living.Domain.Features.Users.Constants;
using Living.Shared.Extensions;

namespace Living.Tests.Auth;
public class TestLoginUser(WebAPIFactory webAPIFactory) : SetupWebAPI(webAPIFactory)
{
    private readonly WebAPIFactory webAPI = webAPIFactory;
    [Fact]
    public async Task ShouldLoginUser()
    {
        var registerUserCommand = RegisterUserFaker.Instance.Generate();
        var responseRegister = await PostAsync<BaseResponse<Guid>>("/api/auth/register", registerUserCommand);
        responseRegister.HttpStatusCode.Should().Be(HttpStatusCode.OK);

        var login = new LoginUserCommand
        {
            Email = registerUserCommand.Email,
            Password = registerUserCommand.Password
        };

        var responseLogin = await Client.PostAsJsonAsync("/api/auth/login", login);
        responseLogin.StatusCode.Should().Be(HttpStatusCode.OK);

        var cookies = responseLogin.GetCookies();

        var accessToken = cookies.FirstOrDefault(p => p.Name == UserCookies.ACCESS_TOKEN);
        accessToken!.Value.Should().NotBeNull();

        var refreshToken = cookies.FirstOrDefault(p => p.Name == UserCookies.REFRESH_TOKEN);
        refreshToken!.Value.Should().NotBeNull();

        var userId = cookies.FirstOrDefault(p => p.Name == UserCookies.USER_ID);
        userId.Should().NotBeNull();
        userId!.Value.IsGuid().Should().BeTrue();

        webAPI.AddCookies(cookies);

        var me = await GetAsync<BaseResponse<UserItemDetails>>("/api/auth/me");

        me.HttpStatusCode.Should().Be(HttpStatusCode.OK);
        me.Data.Should().BeEquivalentTo(new UserItemDetails
        {
            Id = userId!.Value.ToGuid(),
            Name = registerUserCommand.Name,
            Username = registerUserCommand.Username,
            Bio = "",
            Birthday = DateOnly.MinValue,
            CreatedAt = me.Data!.CreatedAt,
            FollowersCount = 0,
            FollowingCount = 0,
            PostsCount = 0
        });

    }

    [Fact]
    public async Task ShouldNotLoginUser_WhenUserNotInvalid()
    {
        var registerUserCommand = RegisterUserFaker.Instance.Generate();
        var response = await PostAsync<BaseResponse>("/api/auth/login", new LoginUserCommand
        {
            Email = registerUserCommand.Email,
            Password = registerUserCommand.Password,
        });

        response.HttpStatusCode.Should().Be(HttpStatusCode.NotFound);

        response.Notifications.Should().ContainKey("USER");
        response.Notifications["USER"].Should().Contain(UserErrors.NOT_FOUND.Code);
    }

    [Fact]
    public async Task ShouldNotLoginUser_WhenPasswordIsInvalid()
    {
        var registerUserCommand = RegisterUserFaker.Instance.Generate();
        var responseRegister = await PostAsync<BaseResponse<Guid>>("/api/auth/register", registerUserCommand);
        responseRegister.HttpStatusCode.Should().Be(HttpStatusCode.OK);

        var response = await PostAsync<BaseResponse>("/api/auth/login", new LoginUserCommand
        {
            Email = registerUserCommand.Email,
            Password = "invalid-password",
        });

        response.HttpStatusCode.Should().Be(HttpStatusCode.BadRequest);
        response.Notifications.Should().ContainKey("USER");
        response.Notifications["USER"].Should().Contain(UserErrors.PASSWORD_INVALID.Code);
    }
}
