using living_backend.DTOs.Request.Users;
using living_backend.Models.Users;
using living_backend.Repositories.Users;
using living_backend.Shared.Password;

namespace living_backend.Services.Users;

public class UserLoginService
{
    private readonly IUserRepository userRepository;
    public UserLoginService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }
    public (bool, string) Login(UserLogin userLogin)
    {
        User? user = userRepository.GetUserByUsername(userLogin.Username);

        if (user == null)
        {
            return (false, "Usuario não encontrado");
        }

        if (!userRepository.CheckPassword(userLogin.Password, user.Password))
        {
            return (false, "Senha invalida");
        }

        return (true, JWT.GenerateToken(user));
    }
}
