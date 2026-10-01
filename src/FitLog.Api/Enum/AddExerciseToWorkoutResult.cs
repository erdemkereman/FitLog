namespace FitLog.Api.Enum;

public enum AddExerciseToWorkoutResult
{
    Success,
    WorkoutNotFound,
    ExerciseNotFound,
    AlreadyExists
}
public enum AddWorkoutSetResult
{
    Success,
    WorkoutExerciseNotFound,
    AlreadyExists
}

public enum UpdateWorkoutSetResult
{
    Success,
    WorkoutSetNotFound,
    AlreadyExists
}