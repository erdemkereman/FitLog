using FitLog.Api.Dtos;
using FitLog.Api.Enums;

namespace FitLog.Api.Interfaces;

public interface ISessionSetService
{
    Task<AddSessionSetResult> AddSessionSetAsync(
        int sessionExerciseId,
        CreateSessionSetDto dto);
}