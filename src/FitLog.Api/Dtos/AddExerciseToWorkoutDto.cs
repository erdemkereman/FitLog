namespace FitLog.Api.Dtos;

public class AddExerciseToWorkoutDto
{
    public int ExerciseId { get; set; }
    public double Weight { get; set; }
    public int RepetitionCount { get; set; }
    public int SetCount { get; set; }
}