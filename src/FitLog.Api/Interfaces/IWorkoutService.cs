using FitLog.Api.Dtos;

namespace FitLog.Api.Interfaces;

public interface IWorkoutService
{
    Task CreateWorkoutAsync(WorkoutDto dto);
}