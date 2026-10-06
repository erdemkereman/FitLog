namespace FitLog.Api.Entities;

public class WorkoutSession
{
    public int Id { get; set; }
    public int WorkoutId { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    
    public Workout Workout { get; set; } = null!;
    
}