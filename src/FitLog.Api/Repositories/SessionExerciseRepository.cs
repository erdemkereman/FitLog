using FitLog.Api.Data;
using FitLog.Api.Entities;
using FitLog.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitLog.Api.Repositories;

public class SessionExerciseRepository : ISessionExerciseRepository
{
    private readonly FitLogDbContext _context;

    public SessionExerciseRepository(FitLogDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistsAsync(int sessionId, int exerciseId)
    {
        return await _context.SessionExercises.AnyAsync(x =>
            x.WorkoutSessionId == sessionId &&
            x.ExerciseId == exerciseId);
    }

    public async Task AddAsync(SessionExercise sessionExercise)
    {
        await _context.SessionExercises.AddAsync(sessionExercise);
        await _context.SaveChangesAsync();
    }
}