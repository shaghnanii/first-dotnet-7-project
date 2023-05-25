using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using shereeni_dotnet.Models.DTO;

namespace shereeni_dotnet.Controllers.Auth;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    public static User user = new User();

    [HttpPost("register")]
    public ActionResult<User> Register(UserDTO request)
    {
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

        user.Name = request.Name;
        user.Password = hashedPassword;

        return Ok(user);
    }
}