
using FitLog.Api.Entities;

namespace FitLog.Api.Interfaces;

public interface IExerciseRepository
{
    Task CreateExerciseAsync(Exercise exercise);
    
    Task<List<Exercise>> GetAllExercisesAsync();
    
    Task<Exercise?> GetExerciseAsync(int id);
    
    Task UpdateExerciseAsync(Exercise exercise);
    
}