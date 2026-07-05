using FitLog.Api.Dtos;

namespace FitLog.Api.Interfaces;

public interface IExerciseRepository
{
    void CreateExercise(CreateExerciseDto dto);
}