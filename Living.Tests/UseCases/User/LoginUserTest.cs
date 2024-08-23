using Living.Application.UseCases.Users.Login;
using Living.Application.UseCases.Users.Register;
using Living.Domain.Features.Users.Constants;
using Living.Domain.Features.Users.Models;
using Living.Tests.Extensions;


namespace Living.Tests.UseCases.User;
public class LoginUserTest(WebAPIFactory webAPIFactory) : SetupWebAPI(webAPIFactory)
{
    [Theory, LivingAutoData]
    public async Task LoginUser_ShouldLoginByEmail(RegisterUserCommand registerUserCommand)
    {
        var responseRegister = await PostAsync<BaseResponse<Guid>>("/api/auth/register", registerUserCommand);
        responseRegister.HttpStatusCode.Should().Be(HttpStatusCode.OK);

        var login = new LoginUserCommand
        {
            EmailOrUsername = registerUserCommand.Email,
            Password = registerUserCommand.Password
        };

        var responseLogin = await Http.PostAsJsonAsync("/api/auth/login", login);
        responseLogin.StatusCode.Should().Be(HttpStatusCode.OK);

        var cookies = responseLogin.GetCookies();

        var accessToken = cookies.FirstOrDefault(p => p.Name == UserCookies.ACCESS_TOKEN);
        accessToken.Should().NotBeNull();
        accessToken.Value.Should().NotBeNull();

        var refreshToken = cookies.FirstOrDefault(p => p.Name == UserCookies.REFRESH_TOKEN);
        refreshToken.Should().NotBeNull();
        refreshToken.Value.Should().NotBeNull();

        var userId = cookies.FirstOrDefault(p => p.Name == UserCookies.USER_ID);
        userId.Should().NotBeNull();
        userId.Value.IsGuid().Should().BeTrue();

        AddCookies(cookies);

        var me = await GetAsync<BaseResponse<UserItemDetails>>("/api/auth/me");

        me.HttpStatusCode.Should().Be(HttpStatusCode.OK);
        me.Data.Should().BeEquivalentTo(new UserItemDetails
        {
            Id = userId.Value.ToGuid(),
            Name = registerUserCommand.Name,
            Username = registerUserCommand.Username,
            Bio = registerUserCommand.Bio,
            Birthday = registerUserCommand.Birthday,
            CreatedAt = me.Data.CreatedAt,
            FollowersCount = 0,
            FollowingCount = 0,
            PostsCount = 0
        });
    }

    [Theory, LivingAutoData]
    public async Task LoginUser_ShouldLoginByUsername(RegisterUserCommand registerUserCommand)
    {
        var responseRegister = await PostAsync<BaseResponse<Guid>>("/api/auth/register", registerUserCommand);
        responseRegister.HttpStatusCode.Should().Be(HttpStatusCode.OK);

        var login = new LoginUserCommand
        {
            EmailOrUsername = registerUserCommand.Username,
            Password = registerUserCommand.Password
        };

        var responseLogin = await Http.PostAsJsonAsync("/api/auth/login", login);
        responseLogin.StatusCode.Should().Be(HttpStatusCode.OK);

        var cookies = responseLogin.GetCookies();

        var accessToken = cookies.FirstOrDefault(p => p.Name == UserCookies.ACCESS_TOKEN);
        accessToken.Should().NotBeNull();
        accessToken.Value.Should().NotBeNull();

        var refreshToken = cookies.FirstOrDefault(p => p.Name == UserCookies.REFRESH_TOKEN);
        refreshToken.Should().NotBeNull();
        refreshToken.Value.Should().NotBeNull();

        var userId = cookies.FirstOrDefault(p => p.Name == UserCookies.USER_ID);
        userId.Should().NotBeNull();
        userId.Value.IsGuid().Should().BeTrue();

        AddCookies(cookies);

        var me = await GetAsync<BaseResponse<UserItemDetails>>("/api/auth/me");

        me.HttpStatusCode.Should().Be(HttpStatusCode.OK);
        me.Data.Should().BeEquivalentTo(new UserItemDetails
        {
            Id = userId.Value.ToGuid(),
            Name = registerUserCommand.Name,
            Username = registerUserCommand.Username,
            Bio = registerUserCommand.Bio,
            Birthday = registerUserCommand.Birthday,
            CreatedAt = me.Data.CreatedAt,
            FollowersCount = 0,
            FollowingCount = 0,
            PostsCount = 0
        });
    }

    [Theory, LivingAutoData]
    public async Task LoginUser_ShouldNotLoginWhenUserNotInvalid(LoginUserCommand command)
    {
        var response = await PostAsync<BaseResponse>("/api/auth/login", command);

        response.HttpStatusCode.Should().Be(HttpStatusCode.NotFound);

        response.Notifications.Should().HaveCount(1);
        response.Notifications.Should().ContainNotification(UserErrors.NOT_FOUND);
    }

    [Theory, LivingAutoData]
    public async Task LoginUser_ShouldNotLoginWhenPasswordIsInvalid(RegisterUserCommand command, string password)
    {
        var responseRegister = await PostAsync<BaseResponse<Guid>>("/api/auth/register", command);
        responseRegister.HttpStatusCode.Should().Be(HttpStatusCode.OK);

        var response = await PostAsync<BaseResponse>("/api/auth/login", new LoginUserCommand
        {
            EmailOrUsername = command.Email,
            Password = password,
        });

        response.HttpStatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        response.Notifications.Should().HaveCount(1);
        response.Notifications.Should().ContainNotification(UserErrors.PASSWORD_INVALID);
    }

    [Theory, LivingAutoData]
    public async Task LoginUser_ShouldNotLoginWhenUserIsLockedOut(RegisterUserCommand command)
    {
        var responseRegister = await PostAsync<BaseResponse<Guid>>("/api/auth/register", command);

        await UserRepository
            .DBSet()
            .Where(p => p.Id == responseRegister.Data)
            .ExecuteUpdateAsync(p => p.SetProperty(x => x.LockoutEnd, DateTimeOffset.UtcNow.AddDays(1))
                .SetProperty(p => p.LockoutEnabled, true));

        var response = await PostAsync<BaseResponse>("/api/auth/login", new LoginUserCommand
        {
            EmailOrUsername = command.Email,
            Password = command.Password,
        });

        response.HttpStatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        response.Notifications.Should().HaveCount(1);
        response.Notifications.Should().ContainNotification(UserErrors.LOCKED_OUT);
    }
}
