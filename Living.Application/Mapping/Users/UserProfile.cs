using Living.Application.UseCases.Users.Register;
using Living.Domain.Entities.Users;

namespace Living.Application.Mapping.Users;
public class UserProfile : BaseProfile
{
    public UserProfile()
    {
        CreateMap<RegisterUserCommand, User>();
    }
}
