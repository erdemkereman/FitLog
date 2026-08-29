namespace FitLog.Api.Entities;

public class Workout
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime WorkoutDate { get; set;}
    public DateTime CreatedAt { get; set; }

    public ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
    
}