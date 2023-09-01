
using living_backend.Models.Users;
using living_backend.Repositories.Users;
using Microsoft.AspNetCore.Authorization;
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

        return Ok(!usernameAvailable);
    }


    [HttpGet("me")]
    public IActionResult GetMe()
    {
        if (!User.Identity!.IsAuthenticated)
        {
            return Unauthorized();
        }

        User user = userRepository.GetUserByUsername(User.Identity.Name!)!;
        return Ok(user);
    }

    [AllowAnonymous, HttpGet("get_profile_user/{username}")]
    public IActionResult GetProfileUser(string username)
    {
        User user = userRepository.GetUserByUsername(username)!;
        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }
}
