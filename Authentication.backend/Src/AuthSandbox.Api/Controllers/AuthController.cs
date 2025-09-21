using Microsoft.AspNetCore.Mvc;
namespace AuthSandbox.Api.Controllers;

[Route("auth/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok("Auth Controller is working!");
    }
}