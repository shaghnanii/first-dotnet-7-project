using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using shereeni_dotnet.Models;
using shereeni_dotnet.Services.UserServices;

namespace shereeni_dotnet.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAllUsers()
    {
        var result = await _userService.GetAllUsers();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    // [Route("{id:int}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var result = await _userService.GetUser(id);
        if (result is null)
            return NotFound("Sorry, the user doesn\'t exist.");
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateUser([FromBody]User user)
    {
        var result = await _userService.CreateUser(user);
        if (result is null)
            return NotFound("Sorry! Nothing found.");
        return Ok(result);
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult<User>> UpdateUser(int id, User request)
    {
        var result = await _userService.UpdateUser(id, request);
        if (result is null)
            return NotFound("Sorry! Nothing found with the provided id.");
        return Ok(result);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<User>> DeleteUser(int id)
    {
        var result = await _userService.DeleteUser(id);
        if (result is null)
            return NotFound("Sorry! Nothing found with the provided id.");
        return Ok(result);
    }
}