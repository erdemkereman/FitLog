using System.ComponentModel.DataAnnotations;

namespace FitLog.Api.Dtos;

public class UpdateWorkoutDto
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; }
    
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Description { get; set; }
    
    [Required]
    public DateTime WorkoutDate { get; set; }
    
    
}