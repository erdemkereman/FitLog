
using FitLog.Api.Entities;

namespace FitLog.Api.Interfaces;

public interface IExerciseRepository
{
    void CreateExercise(Exercise exercise);
}