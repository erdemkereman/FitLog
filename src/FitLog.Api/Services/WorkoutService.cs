using FitLog.Api.Dtos;
using FitLog.Api.Entities;
using FitLog.Api.Interfaces;
using FitLog.Api.Repositories;

namespace FitLog.Api.Services;

public class WorkoutService:IWorkoutService
{
    private readonly IWorkoutRepository _workoutRepository;

    public WorkoutService(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }
    
    public async Task CreateWorkoutAsync(WorkoutDto dto)
    {
        Workout workout = new Workout
        {
            Name = dto.Name,
            Description = dto.Description,
            WorkoutDate = dto.WorkoutDate
        };

       await _workoutRepository.WorkoutCreateAsync(workout);
    }
}