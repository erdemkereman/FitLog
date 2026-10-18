using FitLog.Api.Dtos;
using FitLog.Api.Enums;
using FitLog.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitLog.Api.Controllers;

[ApiController]
[Route("api/SessionExercise/{sessionExerciseId:int}/sets")]
public class SessionSetController : ControllerBase
{
    private readonly ISessionSetService _sessionSetService;

    public SessionSetController(ISessionSetService sessionSetService)
    {
        _sessionSetService = sessionSetService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> AddSessionSet(
        [FromRoute] int sessionExerciseId,
        [FromBody] CreateSessionSetDto dto)
    {
        AddSessionSetResult result =
            await _sessionSetService.AddSessionSetAsync(
                sessionExerciseId, dto);

        return result switch
        {
            AddSessionSetResult.Success =>
                StatusCode(StatusCodes.Status201Created),

            AddSessionSetResult.SessionExerciseNotFound =>
                NotFound("SessionExercise bulunamadı."),

            AddSessionSetResult.InvalidSetData =>
                BadRequest("Set bilgileri geçersiz."),

            AddSessionSetResult.AlreadyExists =>
                Conflict("Bu set numarası bu harekete zaten eklenmiş."),

            _ => StatusCode(StatusCodes.Status500InternalServerError)
        };
    }
}