using Microsoft.AspNetCore.Http;

namespace Living.Application.UseCases.Users.Register;
public class RegisterUserCommand : IRequest<IResult>
{
    public string Name { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
