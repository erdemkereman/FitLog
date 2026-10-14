using FitLog.Api.Enum;

namespace FitLog.Api.Dtos;

public class CreateWorkoutSessionResponse
{
    public CreateWorkoutSessionResult Result { get; set; }
    public WorkoutSessionDto? Session { get; set; }
}