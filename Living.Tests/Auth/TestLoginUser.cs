using Living.Application.UseCases.Users.Login;
using Living.Domain.Entities.Users.Models;
using Living.Tests.Setup.Factory;
using System.Net;

namespace Living.Tests.Auth;
public class TestLoginUser(WebAPIFactory webAPI) : SetupWebAPI(webAPI)
{
    [Fact]
    public async Task ShouldLoginUserUsingBearerToken()
    {
        var registerUserCommand = RegisterUserFaker.Instance.Generate();
        var responseRegister = await PostAsync<BaseResponse<Guid>>("/api/auth/register", registerUserCommand);
        responseRegister.HttpStatusCode.Should().Be(HttpStatusCode.OK);

        var login = new LoginUserCommand
        {
            Email = registerUserCommand.Email,
            Password = registerUserCommand.Password,
            UseCookies = false
        };

        var responseLogin = await PostAsync<BaseResponse<UserLoginResponse>>("/api/auth/login", login);

        responseLogin.HttpStatusCode.Should().Be(HttpStatusCode.OK);
        responseLogin.Data!.AccessToken.Should().NotBeNullOrEmpty();
        responseLogin.Data.RefreshToken.Should().NotBeNullOrEmpty();
        responseLogin.Data.TokenType.Should().Be("Bearer");
        responseLogin.Data.ExpiresIn.Should().BeGreaterThan(0);
    }

    /*[Fact]
    public async Task ShouldLoginUserUsingCookies()
    {
        var registerUserCommand = RegisterUserFaker.Instance.Generate();
        var responseRegister = await client.PostAsJsonAsync("/api/auth/register", registerUserCommand);
        responseRegister.StatusCode.Should().Be(HttpStatusCode.OK);

        var responseLogin = await client.PostAsJsonAsync("/api/auth/login", new LoginUserCommand
        {
            Email = registerUserCommand.Email,
            Password = registerUserCommand.Password,
            UseCookies = true
        });

        responseLogin.EnsureSuccessStatusCode();
        var cookies = responseLogin.Headers.FirstOrDefault(p => p.Key == "Set-Cookie").Value;
        cookies.Should().HaveCount(1);
        var cookie = cookies.First();
        cookie.Should().StartWith(".AspNetCore.Identity.Application=");
    }

    [Fact]
    public async Task ShouldNotLoginUserWhenUserNotInvalid()
    {
        var registerUserCommand = RegisterUserFaker.Instance.Generate();
        var response = await client.PostAsJsonAsync("/api/auth/login", new LoginUserCommand
        {
            Email = registerUserCommand.Email,
            Password = registerUserCommand.Password,
            UseCookies = false
        });

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        var content = await response.Content.ReadFromJsonAsync<BaseResponse>();
        content!.Notifications.Should().ContainKey("USER");
        content.Notifications["USER"].Should().Contain(UserErrors.NOT_FOUND.Code);
    }

    [Fact]
    public async Task ShouldNotLoginUserWhenPasswordIsInvalid()
    {
        var registerUserCommand = RegisterUserFaker.Instance.Generate();
        var responseRegister = await client.PostAsJsonAsync("/api/auth/register", registerUserCommand);
        responseRegister.StatusCode.Should().Be(HttpStatusCode.OK);

        var response = await client.PostAsJsonAsync("/api/auth/login", new LoginUserCommand
        {
            Email = registerUserCommand.Email,
            Password = "invalid-password",
            UseCookies = false
        });

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var content = await response.Content.ReadFromJsonAsync<BaseResponse>();
        content!.Notifications.Should().ContainKey("USER");
        content.Notifications["USER"].Should().Contain(UserErrors.PASSWORD_INVALID.Code);
    }*/
}
