namespace FitLog.Api.Dtos;

public class WorkoutSessionDetailDto
{
    public int Id { get; set; }
    public string WorkoutName { get; set; } = string.Empty;
    public DateTime StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public double? DurationMinutes { get; set; }

    public List<SessionExerciseDetailDto> Exercises { get; set; } = new();
}