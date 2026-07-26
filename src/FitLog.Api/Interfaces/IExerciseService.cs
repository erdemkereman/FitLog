using FitLog.Api.Dtos;

namespace FitLog.Api.Interfaces;

public interface IExerciseService
{
     Task CreateExerciseAsync(CreateExerciseDto dto);
}