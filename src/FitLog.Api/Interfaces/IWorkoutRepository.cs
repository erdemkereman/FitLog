using FitLog.Api.Entities;

namespace FitLog.Api.Interfaces;

public interface IWorkoutRepository
{
    Task WorkoutCreateAsync(Workout workout);
}