using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Dtos;
using TaskManager.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterUserDto dto)
    {
        var registeredUser = _userService.Register(dto);
        return Ok(new {user = registeredUser });
    }


    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginUserDto dto)
    {
        var token = _userService.Login(dto, out var errorMessage);
        if (token == null)
        {
            return BadRequest(new { error = errorMessage });
        }
        return Ok(new { token });
    }

    [Authorize]
    [HttpPost("logout")]
    public IActionResult Logout()
    {
        var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

        _userService.Logout(token);
        return Ok(new { message = "Çıkış Başarılı" });
    }

}