using FitLog.Api.Entities;

namespace FitLog.Api.Interfaces;

public interface IWorkoutSessionRepository
{
    Task CreateWorkoutSessionAsync(WorkoutSession workoutSession);
    Task <WorkoutSession?> GetWorkoutSessionByIdAsync(int id);
    Task UpdateWorkoutSessionAsync(WorkoutSession workoutSession);
    Task<List<WorkoutSession>> GetWorkoutSessionHistoryAsync();
    Task<WorkoutSession?> GetWorkoutSessionDetailAsync(int id);

}