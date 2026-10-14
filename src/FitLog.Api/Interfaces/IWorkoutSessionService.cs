using FitLog.Api.Dtos;
using FitLog.Api.Enum;

namespace FitLog.Api.Interfaces;

public interface IWorkoutSessionService
{
    Task<CreateWorkoutSessionResponse> CreateWorkoutSessionAsync(
        CreateWorkoutSessionDto createWorkoutSessionDto);
}