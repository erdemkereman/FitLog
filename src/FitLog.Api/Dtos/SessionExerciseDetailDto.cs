namespace FitLog.Api.Dtos;

public class SessionExerciseDetailDto
{
    public int Id { get; set; }
    public int ExerciseId { get; set; }
    public string ExerciseName { get; set; } = string.Empty;

    public List<SessionSetDetailDto> Sets { get; set; } = new();
}