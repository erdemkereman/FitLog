using FitLog.Api.Data;
using FitLog.Api.Dtos;
using FitLog.Api.Entities;
using FitLog.Api.Interfaces;

namespace FitLog.Api.Repositories;

public class ExerciseRepository : IExerciseRepository
{
    private readonly FitLogDbContext _context;
    public ExerciseRepository(FitLogDbContext context)
    {
        _context = context;
    }

    public void CreateExercise(Exercise exercise)
    {
        _context.Exercises.Add(exercise);
        _context.SaveChanges();
    }
}