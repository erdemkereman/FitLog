namespace FitLog.Api.Entities;

public class WorkoutSet
{
    public int Id { get; set; }
    public int WorkoutExerciseId { get; set; }
    public int SetNumber { get; set; }
    public double Weight { get; set; }
    public int RepetitionCount { get; set; }

    public WorkoutExercise WorkoutExercise { get; set; } = null!;
}