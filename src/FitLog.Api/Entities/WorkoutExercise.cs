namespace FitLog.Api.Entities;

public class WorkoutExercise
{
    public int Id { get; set; }
    public int WorkoutId { get; set; }
    public int ExerciseId { get; set; }
    public double Weight { get; set; }
    public int RepetititonCount { get; set; }
    public int SetCount { get; set; }
}