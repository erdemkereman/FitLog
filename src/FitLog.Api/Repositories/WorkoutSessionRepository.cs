using FitLog.Api.Data;
using FitLog.Api.Entities;
using FitLog.Api.Interfaces;

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
}