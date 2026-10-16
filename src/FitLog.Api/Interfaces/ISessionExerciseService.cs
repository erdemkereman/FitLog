using FitLog.Api.Dtos;
using FitLog.Api.Enum;


namespace FitLog.Api.Interfaces;

public interface ISessionExerciseService
{
    Task<AddSessionExerciseResult> AddSessionExerciseAsync(
        int sessionId,
        CreateSessionExerciseDto dto);
}