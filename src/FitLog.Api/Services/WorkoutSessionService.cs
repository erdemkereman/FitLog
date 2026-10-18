using FitLog.Api.Dtos;
using FitLog.Api.Entities;
using FitLog.Api.Enum;
using FitLog.Api.Enums;
using FitLog.Api.Interfaces;
using WorkoutSession = FitLog.Api.Entities.WorkoutSession;

namespace FitLog.Api.Services;

public class WorkoutSessionService:IWorkoutSessionService
{
    private readonly IWorkoutSessionRepository _workoutSessionRepository;
    private readonly IWorkoutRepository _workoutRepository;

    public WorkoutSessionService(IWorkoutSessionRepository  workoutSessionRepository, IWorkoutRepository workoutRepository)
    {
        _workoutSessionRepository = workoutSessionRepository;
        _workoutRepository = workoutRepository;
    }
    
    public async Task<CreateWorkoutSessionResponse> CreateWorkoutSessionAsync(
        CreateWorkoutSessionDto createWorkoutSessionDto)
    {
        Workout? workout = await _workoutRepository.GetWorkoutByIdAsync(createWorkoutSessionDto.WorkoutId);
        if (workout is null)
        {
            return new CreateWorkoutSessionResponse
            {
                Result = CreateWorkoutSessionResult.WorkoutNotFound,
                Session = null
            };
        }
       
        WorkoutSession workoutSession = new WorkoutSession
        {
            WorkoutId = createWorkoutSessionDto.WorkoutId,
            StartedAt = DateTime.UtcNow,
            CompletedAt = null
        };
        await _workoutSessionRepository.CreateWorkoutSessionAsync(workoutSession);
        WorkoutSessionDto responseDto = new WorkoutSessionDto
        {
            Id = workoutSession.Id,
            WorkoutId = workoutSession.WorkoutId,
            WorkoutName = workout.Name,
            StartedAt = workoutSession.StartedAt,
            CompletedAt = workoutSession.CompletedAt
        };
        return new CreateWorkoutSessionResponse
        {
            Result = CreateWorkoutSessionResult.Success,
            Session = responseDto
        };
    }

    public async Task<CompleteWorkoutSessionResult> CompleteWorkoutSessionAsync(int id)
    {
        WorkoutSession? workoutSession = await _workoutSessionRepository.GetWorkoutSessionByIdAsync(id);

        if (workoutSession is null)
        {
            return CompleteWorkoutSessionResult.NotFound;
        }

        if (workoutSession.CompletedAt==null)
        {
            workoutSession.CompletedAt=DateTime.UtcNow;
        }
        else
        {
            return CompleteWorkoutSessionResult.AlreadyCompleted;
        }

        await _workoutSessionRepository.UpdateWorkoutSessionAsync(workoutSession);
        return CompleteWorkoutSessionResult.Success;
    }
}