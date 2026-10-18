namespace FitLog.Api.Entities;

public class SessionSet
{
    public int Id { get; set; }

    public int SessionExerciseId { get; set; }

    public int SetNumber { get; set; }

    public decimal Weight { get; set; }

    public int RepetitionCount { get; set; }

    public SessionExercise SessionExercise { get; set; } = null!;
}