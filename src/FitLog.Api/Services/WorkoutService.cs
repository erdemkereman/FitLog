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

    public async Task<List<WorkoutDto>> GetAllWorkoutsAsync()
    {
        List<Workout> workouts = await _workoutRepository.GetAllWorkoutsAsync();

        List<WorkoutDto> workoutDtos = workouts.Select(p => new WorkoutDto
        {
            Name = p.Name,
            Description = p.Description,
            WorkoutDate = p.WorkoutDate
        }).ToList();
        
        return workoutDtos;
    }

    public async Task<WorkoutDto?> GetWorkoutByIdAsync(int id)
    {
        Workout? workout = await _workoutRepository.GetWorkoutByIdAsync(id);

        if (workout is null)
        {
            return null;
        }

        WorkoutDto workoutDto = new WorkoutDto
        {
            Name = workout.Name,
            Description = workout.Description,
            WorkoutDate = workout.WorkoutDate
        };

        return workoutDto;
    }
}