using Microsoft.AspNetCore.Mvc;
using AuthSandbox.Application.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
namespace AuthSandbox.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IClientService _clientService;

    public AuthController(IClientService clientService)
    {
       _clientService = clientService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLogin user)
    {
        var properties = new AuthenticationProperties
        {
            RedirectUri = Url.Action("home")
        };
        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        // RedirectToActionResult
        // IEnumerable<User> res = await _clientService.ClientLogin(user.Email, user.PasswordHash);
        // return Ok(res);
    }

    [HttpPost("register")]
    public async Task<ActionResult<User>> Signin([FromBody] UserRegister user)
    {
        User res = await _clientService.ClientRegister(user.Username, user.Email, user.PasswordHash);
        return Ok(res);
    }

    [HttpGet("home")]
    public IActionResult Home()
    {
        return Ok("Welcome to the AuthSandbox API!");
    }
}