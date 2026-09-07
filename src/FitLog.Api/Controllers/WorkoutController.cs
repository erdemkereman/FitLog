using FitLog.Api.Dtos;
using FitLog.Api.Entities;
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

    [HttpGet]
    public async Task<IActionResult> GetWorkoutsAsync()
    {
        List<WorkoutDto> workouts = await _workoutService.GetAllWorkoutsAsync();
        return Ok(workouts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetWorkoutAsync(int id)
    {
        WorkoutDto? workout = await _workoutService.GetWorkoutByIdAsync(id);
        if (workout == null)
        {
            return NotFound();
        }
        return Ok(workout);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWorkoutAsync([FromRoute] int id, UpdateWorkoutDto updateWorkoutDto)
    {
        bool isUpdated = await _workoutService.UpdateWorkoutAsync(id, updateWorkoutDto);

        if (!isUpdated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWorkoutAsync(int id)
    {
        bool isDeleted = await _workoutService.DeleteWorkoutAsync(id);
        
        if (!isDeleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}