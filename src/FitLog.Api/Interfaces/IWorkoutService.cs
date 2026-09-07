using FitLog.Api.Dtos;
using FitLog.Api.Entities;

namespace FitLog.Api.Interfaces;

public interface IWorkoutService
{
    Task CreateWorkoutAsync(WorkoutDto dto);
    Task<List<WorkoutDto>> GetAllWorkoutsAsync();
    
    Task<WorkoutDto?> GetWorkoutByIdAsync(int id);
    
}