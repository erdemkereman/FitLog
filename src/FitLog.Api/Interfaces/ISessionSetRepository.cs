using FitLog.Api.Entities;

namespace FitLog.Api.Interfaces;

public interface ISessionSetRepository
{
    Task<bool> ExistsAsync(int sessionExerciseId, int setNumber);
    Task AddAsync(SessionSet sessionSet);
}