namespace FitLog.Api.Entities;

public class Exercise
{
    public int Id { get; set; }
    public string MuscleGroup { get; set; }
    public string ExerciseType { get; set; }
    public string EquipmentType { get; set; }
    public string? TutorialUrl { get; set; }
}