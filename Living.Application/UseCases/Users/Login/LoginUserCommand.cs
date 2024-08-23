namespace Living.Application.UseCases.Users.Login;
public class LoginUserCommand : IRequest<BaseResponse>
{
    public string EmailOrUsername { get; set; }
    public string Password { get; set; }
}