namespace FitLog.Api.Dtos;
using System.ComponentModel.DataAnnotations;

public class UpdateExerciseDto
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; }
    [Required]
    [MaxLength(50)]
    public string MuscleGroup { get; set; }
    [Required]
    [MaxLength(50)]
    public string ExerciseType { get; set; }
    [Required] 
    [MaxLength(50)]
    public string EquipmentType { get; set; }
    public string? TutorialUrl { get; set; }
}