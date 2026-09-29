namespace FitLog.Api.Dtos;

public class CreateWorkoutSetDto
{
    public int SetNumber { get; set; }
    public double Weight { get; set; }
    public int RepetitionCount { get; set; }
}