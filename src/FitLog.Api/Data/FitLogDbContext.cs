using FitLog.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitLog.Api.Data;

public class FitLogDbContext : DbContext
{
    public FitLogDbContext(DbContextOptions<FitLogDbContext> options)
        : base(options)
    {
    }

    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
}