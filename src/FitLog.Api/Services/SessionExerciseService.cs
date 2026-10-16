using FitLog.Api.Data;
using FitLog.Api.Dtos;
using FitLog.Api.Entities;
using FitLog.Api.Enum;
using FitLog.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitLog.Api.Services;

public class SessionExerciseService : ISessionExerciseService
{
    private readonly FitLogDbContext _context;
    private readonly ISessionExerciseRepository _sessionExerciseRepository;

    public SessionExerciseService(
        FitLogDbContext context,
        ISessionExerciseRepository sessionExerciseRepository)
    {
        _context = context;
        _sessionExerciseRepository = sessionExerciseRepository;
    }

    public async Task<AddSessionExerciseResult> AddSessionExerciseAsync(
        int sessionId,
        CreateSessionExerciseDto dto)
    {
        bool sessionExists = await _context.WorkoutSessions
            .AnyAsync(x => x.Id == sessionId);

        if (!sessionExists)
            return AddSessionExerciseResult.SessionNotFound;

        bool exerciseExists = await _context.Exercises
            .AnyAsync(x => x.Id == dto.ExerciseId);

        if (!exerciseExists)
            return AddSessionExerciseResult.ExerciseNotFound;

        bool alreadyExists = await _sessionExerciseRepository
            .ExistsAsync(sessionId, dto.ExerciseId);

        if (alreadyExists)
            return AddSessionExerciseResult.AlreadyExists;

        SessionExercise sessionExercise = new SessionExercise
        {
            WorkoutSessionId = sessionId,
            ExerciseId = dto.ExerciseId
        };

        await _sessionExerciseRepository.AddAsync(sessionExercise);

        return AddSessionExerciseResult.Success;
    }
}