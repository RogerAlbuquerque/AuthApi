using Microsoft.AspNetCore.Mvc;
using AuthSandbox.Application.Interfaces;
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
        IEnumerable<User> res = await _clientService.ClientLogin(user.Email, user.PasswordHash);
        return Ok(res);
    }

     [HttpPost("register")]
    public async Task<IActionResult> Signin([FromBody] UserRegister user)
    {
        string res = await _clientService.ClientRegister(user.Username, user.Email, user.PasswordHash);
        Console.WriteLine(res);
        Console.WriteLine(user.Email);
        Console.WriteLine(user.PasswordHash);
        return Ok(res);
    }
}