using FitLog.Api.Dtos.Auth;
using FitLog.Api.Enum;

namespace FitLog.Api.Interfaces;

public interface IAuthService
{
    Task<RegisterResult> RegisterAsync(RegisterRequestDto registerRequestDto);
}