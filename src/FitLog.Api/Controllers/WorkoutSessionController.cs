using FitLog.Api.Dtos;
using FitLog.Api.Enum;
using FitLog.Api.Enums;
using FitLog.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitLog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkoutSessionController: ControllerBase
{
    private readonly IWorkoutSessionService  _workoutSessionService;

    public WorkoutSessionController(IWorkoutSessionService  workoutSessionService)
    {
        _workoutSessionService = workoutSessionService;
    }
    [HttpPost]
    public async Task<IActionResult> CreateWorkoutSession(
        CreateWorkoutSessionDto createWorkoutSessionDto)
    {
        CreateWorkoutSessionResponse response =
            await _workoutSessionService.CreateWorkoutSessionAsync(createWorkoutSessionDto);

        return response.Result switch
        {
            CreateWorkoutSessionResult.Success =>
                StatusCode(StatusCodes.Status201Created, response.Session),

            CreateWorkoutSessionResult.WorkoutNotFound =>
                NotFound("Workout bulunamadı."),

            _ => StatusCode(StatusCodes.Status500InternalServerError)
        };
    }

    [HttpPatch("{id:int}/complete")]
    public async Task<IActionResult> CompleteWorkoutSession(int id)
    {
        CompleteWorkoutSessionResult result= await _workoutSessionService.CompleteWorkoutSessionAsync(id);

        return result switch
        {
            CompleteWorkoutSessionResult.Success => Ok("Antrenman başarıyla tamamlandı."),
            CompleteWorkoutSessionResult.NotFound => NotFound("Antrenman bulunamadı."),
            CompleteWorkoutSessionResult.AlreadyCompleted => Conflict("Bu antrenman zaten tamamlanmış."),
            _ => StatusCode(StatusCodes.Status500InternalServerError,
                "Beklenmeyen bir hata oluştu.")
        };

    }
}