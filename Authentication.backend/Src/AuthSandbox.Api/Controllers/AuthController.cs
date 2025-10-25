using Microsoft.AspNetCore.Mvc;
using AuthSandbox.Application.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
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

    // [Authorize]
    [HttpGet("login")]
    public async Task<IActionResult> Login()
    {
        var redirectUrl = Url.Action("GoogleResponse", "Auth", new { nomeVar = "valorVarNaUrl" }); 
        
        var properties = new AuthenticationProperties { RedirectUri = redirectUrl }; //Define que, após o login no Google, o usuário deve ser redirecionado para redirectUrl
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

    [HttpGet("signin-google")]
    public async Task<IActionResult> GoogleResponse(string returnUrl = "/")
    {
        var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme); // Autentica o usuário usando o esquema de cookies

        if (!result.Succeeded)
            return BadRequest(); // ou redirecionar para uma página de erro

        // Aqui você pode acessar os dados do usuário autenticado
        var claims = result.Principal.Identities.FirstOrDefault()?.Claims;
        var email = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        var name = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

        // Redireciona para o frontend ou retorna um token, se preferir
        return Ok(email);
    }

    
    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Home");
    }
}