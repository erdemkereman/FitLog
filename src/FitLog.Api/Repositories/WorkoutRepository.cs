using FitLog.Api.Data;
using FitLog.Api.Entities;
using FitLog.Api.Interfaces;

namespace FitLog.Api.Repositories;

public class WorkoutRepository:IWorkoutRepository
{
    private readonly FitLogDbContext _context;
    public WorkoutRepository(FitLogDbContext context)
    {
        _context = context;
    }
    
    public Task WorkoutCreateAsync(Workout workout)
    {
        _context.Workouts.Add(workout);
        return _context.SaveChangesAsync();
    }
}