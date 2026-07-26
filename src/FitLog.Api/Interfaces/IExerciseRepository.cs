
using FitLog.Api.Entities;

namespace FitLog.Api.Interfaces;

public interface IExerciseRepository
{
    Task CreateExerciseAsync(Exercise exercise);
}