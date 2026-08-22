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

    public async Task<List<ExerciseDto>> GetAllExercisesAsync()
    {
        List<Exercise> exercises = await _exerciseRepository.GetAllExercisesAsync();

        List<ExerciseDto> exerciseDtos = exercises.Select(p => new ExerciseDto
        {
            Id = p.Id,
            Name = p.Name,
            MuscleGroup = p.MuscleGroup,
            ExerciseType = p.ExerciseType,
            EquipmentType = p.EquipmentType,
            TutorialUrl = p.TutorialUrl
        }).ToList();

        return exerciseDtos;
    }

    public async Task<ExerciseDto?> GetExerciseByIdAsync(int id)
    {
        Exercise? exercises = await _exerciseRepository.GetExerciseAsync(id);
        if (exercises is null)
        {
            return null;
        }

        ExerciseDto exerciseDto = new ExerciseDto()
        {
            Id =  exercises.Id,
            Name = exercises.Name,
            MuscleGroup = exercises.MuscleGroup,
            ExerciseType = exercises.ExerciseType,
            EquipmentType = exercises.EquipmentType,
            TutorialUrl = exercises.TutorialUrl
        };
        return exerciseDto;
    }
}