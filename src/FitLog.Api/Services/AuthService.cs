using FitLog.Api.Dtos.Auth;
using FitLog.Api.Entities;
using FitLog.Api.Enum;
using FitLog.Api.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace FitLog.Api.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    private readonly PasswordHasher<User> _passwordHasher =
        new PasswordHasher<User>();

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
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
}