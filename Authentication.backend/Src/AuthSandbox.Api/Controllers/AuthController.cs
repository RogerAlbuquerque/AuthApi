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

    [HttpGet]
    public async Task<IActionResult> Login()
    {
        IEnumerable<User> res = await _clientService.ClientLogin();
        return Ok(res);
    }
}