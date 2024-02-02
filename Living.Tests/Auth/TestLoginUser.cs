using Living.Application.UseCases.Users.Login;
using Living.Domain.Entities.Users.Models;
using System.Net;
using System.Net.Http.Json;

namespace Living.Tests.Auth;
public class TestLoginUser : SetupWebAPI
{
    [Fact]
    public async Task ShouldLoginUserUsingBearerToken()
    {
        var registerUserCommand = RegisterUserFaker.Instance.Generate();
        var responseRegister = await client.PostAsJsonAsync("/api/auth/register", registerUserCommand);

        responseRegister.StatusCode.Should().Be(HttpStatusCode.OK);

        var responseLogin = await client.PostAsJsonAsync("/api/auth/login", new LoginUserCommand
        {
            Email = registerUserCommand.Email,
            Password = registerUserCommand.Password,
            UseCookies = false
        });

        responseLogin.EnsureSuccessStatusCode();
        var content = (await responseLogin.Content.ReadFromJsonAsync<UserLoginResponse>())!;
        content.AccessToken.Should().NotBeNullOrEmpty();
        content.RefreshToken.Should().NotBeNullOrEmpty();
        content.TokenType.Should().Be("Bearer");
        content.ExpiresIn.Should().BeGreaterThan(0);
    }

    [Fact]
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
}
