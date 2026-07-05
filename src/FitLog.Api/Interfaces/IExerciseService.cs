using FitLog.Api.Dtos;

namespace FitLog.Api.Interfaces;

public interface IExerciseService
{
     void CreateExercise(CreateExerciseDto dto);
}