using FitLog.Api.Dtos;
using FitLog.Api.Entities;
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
        Exercise exercise = new Exercise
        {
            Name =  dto.Name,
            ExerciseType =  dto.ExerciseType,
            MuscleGroup = dto.MuscleGroup,
            EquipmentType = dto.EquipmentType,
            TutorialUrl = dto.TutorialUrl,
        };
        _exerciseRepository.CreateExercise(exercise);
    }
}