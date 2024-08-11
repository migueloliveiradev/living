using Living.Application.UseCases.Users.Login;
using Living.Application.UseCases.Users.Register;

namespace Living.Tests.Setup;
public partial class SetupWebAPI
{
#pragma warning disable IDE0060
    protected async Task LoginAsync(string? permission = null)
    {
        var register = await RegisterAsync();

        var token = await LoginWebAPIAsync(register.Email, register.Password);

        //webAPI.AddBearerToken(token);

        // TODO: Add permission
    }

    private async Task<RegisterUserCommand> RegisterAsync()
    {
        var registerUserCommand = RegisterUserFaker.Instance.Generate();
        var responseRegister = await PostAsync<BaseResponse<Guid>>("/api/auth/register", registerUserCommand);

        if (responseRegister.HasNotifications)
            throw new Exception(responseRegister.Notifications.ToString());

        return registerUserCommand;
    }

    private async Task<string> LoginWebAPIAsync(string email, string password)
    {
        var command = new LoginUserCommand
        {
            Email = email,
            Password = password,
        };

        var responseLogin = await PostAsync<BaseResponse>("/api/auth/login", command);

        if (responseLogin.HasNotifications)
            throw new Exception(responseLogin.Notifications.ToString());

        return "responseLogin.Data!.AccessToken";
    }
}
