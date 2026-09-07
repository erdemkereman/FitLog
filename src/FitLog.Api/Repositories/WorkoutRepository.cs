using FitLog.Api.Data;
using FitLog.Api.Entities;
using FitLog.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

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

    public async Task<List<Workout>> GetAllWorkoutsAsync()
    {
       List<Workout> workouts= await _context.Workouts.ToListAsync();
       return workouts;
    }

    public async Task<Workout?> GetWorkoutByIdAsync(int id)
    {
        Workout? workout = await _context.Workouts.FindAsync(id);
        return workout;
    }
}