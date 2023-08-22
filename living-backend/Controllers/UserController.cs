using living_backend.Repositories.Users;
using Microsoft.AspNetCore.Mvc;

namespace living_backend.Controllers;
public class UserController : Controller
{
    private readonly IUserRepository userRepository;
    public UserController(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }
    public IActionResult Index()
    {
        return View();
    }
}
