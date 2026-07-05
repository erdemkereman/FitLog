using FitLog.Api.Dtos;
using FitLog.Api.Interfaces;

namespace FitLog.Api.Services;

public class ExerciseService:IExerciseService
{
    private readonly IExerciseRepository _exerciseRepository;
    public ExerciseService(IExerciseRepository  exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }
    
    public void CreateExercise(CreateExerciseDto dto)
    {
        _exerciseRepository.CreateExercise(dto);
    }
}