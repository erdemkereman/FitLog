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

    public Task UpdateWorkoutAsync(Workout workout)
    {
        _context.Workouts.Update(workout);
        return _context.SaveChangesAsync();
    }

    public Task DeleteWorkoutAsync(Workout workout)
    {
        _context.Workouts.Remove(workout);
        return _context.SaveChangesAsync();
    }

    public Task AddWorkoutExerciseAsync(WorkoutExercise workoutExercise)
    {
        _context.WorkoutExercises.Add(workoutExercise);
        return _context.SaveChangesAsync();
    }
    
    public async Task<bool> WorkoutExerciseExistsAsync(
        int workoutId,
        int exerciseId)
    {
        return await _context.WorkoutExercises.AnyAsync(x =>
            x.WorkoutId == workoutId &&
            x.ExerciseId == exerciseId);
    }

    public async Task<List<WorkoutExercise>> GetWorkoutExercisesAsync(int workoutId)
    {
        List<WorkoutExercise> workoutExercises = await _context.WorkoutExercises.Where(x => x.WorkoutId == workoutId)
            .Include(x => x.Exercise).ToListAsync();
        
        return workoutExercises;
        
    }
}