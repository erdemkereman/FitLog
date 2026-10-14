using FitLog.Api.Entities;

namespace FitLog.Api.Interfaces;

public interface IWorkoutSessionRepository
{
    Task CreateWorkoutSessionAsync(WorkoutSession workoutSession);
}