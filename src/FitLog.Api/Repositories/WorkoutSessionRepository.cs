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
}