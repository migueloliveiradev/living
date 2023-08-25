using living_backend.DTOs.Request.Users;
using living_backend.DTOs.Response.Users;
using living_backend.Models.Users;
using living_backend.Repositories.Users;
using living_backend.Services.Users;
using living_backend.Shared.Password;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace living_backend.Controllers;
public class LoginController : Controller
{
    private readonly IUserRepository userRepository;
    private readonly UserLoginService userLoginService;
    public LoginController(IUserRepository userRepository, UserLoginService userLoginService)
    {
        this.userRepository = userRepository;
        this.userLoginService = userLoginService;
    }

    [HttpPost("/register")]
    public IActionResult Register([FromBody] UserRequest userRequest)
    {
        if (userRepository.CheckUsernameExists(userRequest.Username))
        {
            ModelState.AddModelError("Username", "username não disponivel");
        }

        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(new UserRegisterResponse(ModelState));
        }

        User user = userRequest.ToUser();
        User userCreated = userRepository.Create(user);

        string token = JWT.GenerateToken(userCreated);

        return Json(new UserRegisterResponse(token, true));
    }

    [HttpPost("/login")]
    public IActionResult Login([FromBody] UserLogin userLogin)
    {
        (bool sucess, string menssage) teste = userLoginService.Login(userLogin);

        if (!teste.sucess)
        {
            return BadRequest(new { error = teste.menssage });
        }

        User user = userRepository.GetUserByUsername(userLogin.Username)!;

        string token = JWT.GenerateToken(user);

        return Json(new { token });
    }

    [Authorize]
    [HttpGet("/test")]
    public IActionResult Test()
    {
        return Json(new { message = "Hello World", user = User.Identity!.Name });
    }
}
