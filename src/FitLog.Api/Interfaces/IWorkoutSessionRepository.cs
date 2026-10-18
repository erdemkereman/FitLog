using FitLog.Api.Entities;

namespace FitLog.Api.Interfaces;

public interface IWorkoutSessionRepository
{
    Task CreateWorkoutSessionAsync(WorkoutSession workoutSession);
    Task <WorkoutSession?> GetWorkoutSessionByIdAsync(int id);
    Task UpdateWorkoutSessionAsync(WorkoutSession workoutSession);
    
}