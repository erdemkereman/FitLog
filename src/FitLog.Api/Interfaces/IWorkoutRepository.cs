using FitLog.Api.Entities;

namespace FitLog.Api.Interfaces;

public interface IWorkoutRepository
{
    Task WorkoutCreateAsync(Workout workout);
    Task <List<Workout>> GetAllWorkoutsAsync();
    Task <Workout?> GetWorkoutByIdAsync(int id);
   
}