using FitLog.Api.Dtos.Auth;
using FitLog.Api.Enum;
using FitLog.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace FitLog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(
        [FromBody] RegisterRequestDto registerRequestDto)
    {
        var result = await _authService.RegisterAsync(registerRequestDto);

        return result switch
        {
            RegisterResult.Success =>
                StatusCode(StatusCodes.Status201Created,
                    new { Message = "User registered successfully." }),

            RegisterResult.EmailAlreadyExists =>
                Conflict(new { Message = "Email is already registered." }),
            
            RegisterResult.UsernameAlreadyExists =>
                Conflict(new { Message = "Username is already taken." }),

            _ => StatusCode(StatusCodes.Status500InternalServerError)
        };
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(
        [FromBody] LoginRequestDto loginRequestDto)
    {
        var result = await _authService.LoginAsync(loginRequestDto);

        if (result == null)
        {
            return Unauthorized(new
            {
                Message = "Invalid credentials."
            });
        }

        return Ok(result);
    }
    
    [Authorize]
    [HttpGet("me")]
    public IActionResult Me()
    {
        var userId = User.FindFirstValue(
            ClaimTypes.NameIdentifier);

        var username = User.FindFirstValue(
            ClaimTypes.Name);

        return Ok(new
        {
            UserId = userId,
            Username = username
        });
    }
}