namespace FitLog.Api.Dtos;

public class WorkoutExerciseDto
{
    public int ExerciseId { get; set; }
    public string ExerciseName { get; set; }
    public double Weight { get; set; }
    public int RepetitionCount { get; set; }
    public int SetCount { get; set; }
}