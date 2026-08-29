using FitLog.Api.Dtos;
using FitLog.Api.Interfaces;
using FitLog.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitLog.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class WorkoutController:ControllerBase
{ 
    private readonly IWorkoutService _workoutService;

    public WorkoutController(IWorkoutService workoutService)
    {
        _workoutService = workoutService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateWorkoutAsync(WorkoutDto workoutDto)
    {
        await _workoutService.CreateWorkoutAsync(workoutDto);
        return Ok(workoutDto);
    }
}