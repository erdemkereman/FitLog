using FitLog.Api.Dtos;
using FitLog.Api.Entities;
using FitLog.Api.Enum;
using FitLog.Api.Enums;

namespace FitLog.Api.Interfaces;

public interface IWorkoutSessionService
{
    Task<CreateWorkoutSessionResponse> CreateWorkoutSessionAsync(
        CreateWorkoutSessionDto createWorkoutSessionDto);
    
    Task<CompleteWorkoutSessionResult> CompleteWorkoutSessionAsync(int id);
    Task<List<WorkoutSessionHistoryDto>> GetWorkoutSessionHistoryAsync();
    Task<WorkoutSessionDetailDto?> GetWorkoutSessionDetailAsync(int id);
}