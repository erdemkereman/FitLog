namespace FitLog.Api.Dtos;

public class PreviousExercisePerformanceDto
{
    public string ExerciseName { get; set; }
    public DateTime LastWorkoutDate { get; set; }
    
    public ICollection<SessionSetDetailDto> SessionSetDetails { get; set; }
        = new List<SessionSetDetailDto>();
}