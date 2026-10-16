using FitLog.Api.Entities;

namespace FitLog.Api.Interfaces;

public interface ISessionExerciseRepository
{
    Task<bool> ExistsAsync(int sessionId, int exerciseId);

    Task AddAsync(SessionExercise sessionExercise);
}