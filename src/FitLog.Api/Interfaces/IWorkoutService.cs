using FitLog.Api.Dtos;
using FitLog.Api.Entities;
using FitLog.Api.Enum;

namespace FitLog.Api.Interfaces;

public interface IWorkoutService
{
    Task CreateWorkoutAsync(WorkoutDto dto);
    Task<List<WorkoutDto>> GetAllWorkoutsAsync();
    
    Task<WorkoutDto?> GetWorkoutByIdAsync(int id);
    
    Task<bool> UpdateWorkoutAsync(int id,UpdateWorkoutDto updateWorkoutDto);
    
    Task<bool> DeleteWorkoutAsync(int id);
    
    Task<AddExerciseToWorkoutResult> CreateWorkoutExerciseAsync(
        int workoutId,
        AddExerciseToWorkoutDto addExerciseToWorkoutDto);
    
}