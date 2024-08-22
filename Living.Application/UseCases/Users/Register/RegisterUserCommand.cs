using Living.Domain.Features.Users;

namespace Living.Application.UseCases.Users.Register;
public class RegisterUserCommand : IRequest<BaseResponse<Guid>>
{
    public string Name { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Bio { get; set; }
    public DateOnly Birthday { get; set; }

    public User ToUser()
    {
        return new()
        {
            Name = Name,
            UserName = Username,
            Email = Email,
            Bio = Bio,
            Birthday = Birthday
        };
    }
}