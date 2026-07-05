namespace FitLog.Api.Dtos;

public class CreateExerciseDto
{
    public string Name { get; set; }
    public string MuscleGroup { get; set; }
    public string ExerciseType { get; set; }
    public string EquipmentType { get; set; }
    public string? TutorialUrl { get; set; }
}