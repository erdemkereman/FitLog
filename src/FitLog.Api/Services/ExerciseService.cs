using FitLog.Api.Dtos;
using FitLog.Api.Entities;
using FitLog.Api.Interfaces;


namespace FitLog.Api.Services;

public class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository _exerciseRepository;

    public ExerciseService(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    public async Task CreateExerciseAsync(CreateExerciseDto dto)
    {
        if (dto is null)
        {
            throw new ArgumentNullException(nameof(dto));
        }

        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            throw new ArgumentException(nameof(dto.Name));
        }

        if (string.IsNullOrWhiteSpace(dto.MuscleGroup))
        {
            throw new ArgumentException(nameof(dto.MuscleGroup));
        }

        if (string.IsNullOrWhiteSpace(dto.ExerciseType))
        {
            throw new ArgumentException(nameof(dto.ExerciseType));
        }

        if (string.IsNullOrWhiteSpace(dto.EquipmentType))
        {
            throw new ArgumentException(nameof(dto.EquipmentType));
        }

        if (string.IsNullOrWhiteSpace(dto.TutorialUrl))
        {
            throw new ArgumentException(nameof(dto.TutorialUrl));
        }

        Exercise exercise = new Exercise
        {
            Name = dto.Name,
            ExerciseType = dto.ExerciseType,
            MuscleGroup = dto.MuscleGroup,
            EquipmentType = dto.EquipmentType,
            TutorialUrl = dto.TutorialUrl,
        };
        await _exerciseRepository.CreateExerciseAsync(exercise);
    }
}