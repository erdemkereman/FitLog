namespace FitLog.Api.Dtos;

public class WorkoutSessionDto
{
    public int Id { get; set; }
    public int WorkoutId { get; set; }
    public string WorkoutName { get; set; } = null!;
    public DateTime StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
}