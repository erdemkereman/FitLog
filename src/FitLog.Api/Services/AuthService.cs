using FitLog.Api.Dtos.Auth;
using FitLog.Api.Entities;
using FitLog.Api.Enum;
using FitLog.Api.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace FitLog.Api.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenService _jwtTokenService;

    private readonly PasswordHasher<User> _passwordHasher
        = new PasswordHasher<User>();

    public AuthService(
        IUserRepository userRepository,
        IJwtTokenService jwtTokenService)
    {
        _userRepository = userRepository;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<RegisterResult> RegisterAsync(RegisterRequestDto registerRequestDto)
    {
        var mail = await _userRepository.GetByEmailAsync(registerRequestDto.Email);

        if (mail != null)
        {
            return RegisterResult.EmailAlreadyExists;
        }
        
        var existingUser = await _userRepository.GetByUsernameAsync(registerRequestDto.Username);

        if (existingUser != null)
        {
            return RegisterResult.UsernameAlreadyExists;
        }

        var user = new User
        {
            Username = registerRequestDto.Username,
            Email = registerRequestDto.Email,
            CreatedAt = DateTime.UtcNow
        };

        user.PasswordHash = _passwordHasher.HashPassword(
            user,
            registerRequestDto.Password
        );

        await _userRepository.AddAsync(user);

        return RegisterResult.Success;
    }

    public async Task<LoginResponseDto?> LoginAsync(
        LoginRequestDto loginRequestDto)
    {
        User? user;

        if (loginRequestDto.Identifier.Contains("@"))
        {
            user = await _userRepository.GetByEmailAsync(
                loginRequestDto.Identifier);
        }
        else
        {
            user = await _userRepository.GetByUsernameAsync(
                loginRequestDto.Identifier);
        }

        if (user == null)
        {
            return null;
        }

        var passwordResult = _passwordHasher.VerifyHashedPassword(
            user,
            user.PasswordHash,
            loginRequestDto.Password);

        if (passwordResult != PasswordVerificationResult.Success &&
            passwordResult != PasswordVerificationResult.SuccessRehashNeeded)
        {
            return null;
        }

        var token = _jwtTokenService.GenerateJwtToken(user);

        return new LoginResponseDto
        {
            AccessToken = token
        };
    }
}