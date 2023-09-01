using living_backend.Repositories.Users;
using Microsoft.AspNetCore.Mvc;

namespace living_backend.Controllers;

[Authorize, Route("/user")]
public class UserController : ControllerBase
{
    private readonly IUserRepository userRepository;
    public UserController(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }
    [HttpGet("check_username_available/")]
    public IActionResult CheckUsernameAvailable(string username)
    {
        bool usernameAvailable = userRepository.CheckUsernameExists(username);

        return Json(!usernameAvailable);
    }
}
