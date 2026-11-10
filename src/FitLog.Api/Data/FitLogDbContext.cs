using FitLog.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitLog.Api.Data;

public class FitLogDbContext : DbContext
{
    public FitLogDbContext(DbContextOptions<FitLogDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
    }
    
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
    public DbSet<WorkoutSet> WorkoutSets { get; set; }
    
    public DbSet<WorkoutSession> WorkoutSessions { get; set; }
    public DbSet<SessionExercise> SessionExercises { get; set; }
    public DbSet<SessionSet> SessionSets { get; set; }
    
    public DbSet<User> Users { get; set; }
}