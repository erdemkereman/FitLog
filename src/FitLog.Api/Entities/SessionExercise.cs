namespace FitLog.Api.Entities;

public class SessionExercise
{
    public int Id { get; set; }

    public int WorkoutSessionId { get; set; }
    public int ExerciseId { get; set; }

    public WorkoutSession WorkoutSession { get; set; } = null!;
    public Exercise Exercise { get; set; } = null!;
    public ICollection<SessionSet> SessionSets { get; set; } = new List<SessionSet>();
}