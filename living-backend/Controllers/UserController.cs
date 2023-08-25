using living_backend.Repositories.Users;
using Microsoft.AspNetCore.Mvc;

namespace living_backend.Controllers;
[Route("/user")]
public class UserController : Controller
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
