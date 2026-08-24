using FitLog.Api.Data;
using FitLog.Api.Entities;
using FitLog.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitLog.Api.Repositories;

public class ExerciseRepository : IExerciseRepository
{
    private readonly FitLogDbContext _context;
    public ExerciseRepository(FitLogDbContext context)
    {
        _context = context;
    }
    
    public async Task CreateExerciseAsync(Exercise exercise)
    { 
        _context.Exercises.Add(exercise);
       await _context.SaveChangesAsync();
    }

    public async Task<List<Exercise>> GetAllExercisesAsync()
    {
        List<Exercise> exercises= await _context.Exercises.ToListAsync();
        return exercises;
    }

    public async Task<Exercise?> GetExerciseAsync(int id)
    {
        Exercise? exercise= await _context.Exercises.FindAsync(id);
        return exercise;
    }

    public Task UpdateExerciseAsync(Exercise exercise)
    {
        _context.Exercises.Update(exercise);
        return _context.SaveChangesAsync();
    }

    public Task DeleteExerciseAsync(Exercise exercise)
    {
        _context.Exercises.Remove(exercise);
        return _context.SaveChangesAsync();
    }
}