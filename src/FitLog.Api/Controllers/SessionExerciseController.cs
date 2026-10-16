using FitLog.Api.Dtos;
using FitLog.Api.Enum;
using FitLog.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitLog.Api.Controllers;

[ApiController]
[Route("api/WorkoutSession/{sessionId:int}/exercises")]
public class SessionExerciseController : ControllerBase
{
    private readonly ISessionExerciseService _sessionExerciseService;

    public SessionExerciseController(
        ISessionExerciseService sessionExerciseService)
    {
        _sessionExerciseService = sessionExerciseService;
    }

    [HttpPost]
    public async Task<IActionResult> AddSessionExercise(
        int sessionId,
        [FromBody] CreateSessionExerciseDto dto)
    {
        AddSessionExerciseResult result =
            await _sessionExerciseService.AddSessionExerciseAsync(sessionId, dto);

        return result switch
        {
            AddSessionExerciseResult.Success =>
                StatusCode(StatusCodes.Status201Created),

            AddSessionExerciseResult.SessionNotFound =>
                NotFound("WorkoutSession bulunamadı."),

            AddSessionExerciseResult.ExerciseNotFound =>
                NotFound("Exercise bulunamadı."),

            AddSessionExerciseResult.AlreadyExists =>
                Conflict("Bu egzersiz session'a zaten eklenmiş."),

            _ => StatusCode(StatusCodes.Status500InternalServerError)
        };
    }
}