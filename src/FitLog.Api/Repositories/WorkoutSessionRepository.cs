using FitLog.Api.Data;
using FitLog.Api.Entities;
using FitLog.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitLog.Api.Repositories;

public class WorkoutSessionRepository:IWorkoutSessionRepository
{
    private FitLogDbContext  _context;
    public WorkoutSessionRepository(FitLogDbContext context)
    {
        _context = context;
    }
    
    public Task CreateWorkoutSessionAsync(WorkoutSession workoutSession)
    {
        _context.WorkoutSessions.Add(workoutSession);
        return _context.SaveChangesAsync();
    }

    public Task<WorkoutSession?> GetWorkoutSessionByIdAsync(int id)
    {
        return _context.WorkoutSessions.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task UpdateWorkoutSessionAsync(WorkoutSession workoutSession)
    {
        _context.WorkoutSessions.Update(workoutSession);
        return _context.SaveChangesAsync();
    }

    public Task<List<WorkoutSession>> GetWorkoutSessionHistoryAsync()
    {
        return _context.WorkoutSessions.Include(x => x.Workout).Where(x => x.CompletedAt != null).OrderByDescending(x => x.StartedAt).ToListAsync();
        
    }

    public Task<WorkoutSession?> GetWorkoutSessionDetailAsync(int id)
    {
        Task<WorkoutSession?> workoutSession = _context.WorkoutSessions
            .Include(x => x.Workout)
            .Include(x => x.SessionExercises)
            .ThenInclude(x => x.Exercise)
            .Include(x => x.SessionExercises).ThenInclude(x => x.SessionSets)
            .FirstOrDefaultAsync(x => x.Id == id);
        
        return workoutSession;

    }
}