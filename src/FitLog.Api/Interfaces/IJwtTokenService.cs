using FitLog.Api.Entities;

namespace FitLog.Api.Interfaces;

public interface IJwtTokenService
{
    String GenerateJwtToken(User user);
}