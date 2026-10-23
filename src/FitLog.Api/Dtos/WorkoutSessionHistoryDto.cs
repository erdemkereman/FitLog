namespace FitLog.Api.Dtos;

public class WorkoutSessionHistoryDto
{
    public int Id { get; set; }
    public string WorkoutName { get; set; } = string.Empty;
    public DateTime StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public double? DurationMinutes { get; set; }
}