namespace FitLog.Api.Entities;

public class Workout
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime WorkoutDate { get; set;}

    public ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
    
}