using FitLog.Api.Dtos;
using FitLog.Api.Entities;
using FitLog.Api.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;


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
        Exercise? exercise = await _exerciseRepository.GetExerciseAsync(id);
        if (exercise is null)
        {
            return null;
        }

        ExerciseDto exerciseDto = new ExerciseDto()
        {
            Id =  exercise.Id,
            Name = exercise.Name,
            MuscleGroup = exercise.MuscleGroup,
            ExerciseType = exercise.ExerciseType,
            EquipmentType = exercise.EquipmentType,
            TutorialUrl = exercise.TutorialUrl
        };
        return exerciseDto;
    }

    public async Task<bool> UpdateExerciseAsync(int id,UpdateExerciseDto dto)
    {
        Exercise? exercise = await _exerciseRepository.GetExerciseAsync(id);
        if (exercise is null)
        {
            return false;
        }
        exercise.Name = dto.Name;
        exercise.MuscleGroup = dto.MuscleGroup;
        exercise.ExerciseType = dto.ExerciseType;
        exercise.EquipmentType = dto.EquipmentType;
        exercise.TutorialUrl = dto.TutorialUrl;
        await _exerciseRepository.UpdateExerciseAsync(exercise);
        return true;

    }

    public async Task<bool> DeleteExerciseAsync(int id)
    {
        Exercise? exercise = await _exerciseRepository.GetExerciseAsync(id);
        if (exercise is null)
        {
            return false;
        }
        await _exerciseRepository.DeleteExerciseAsync(exercise);
        return true;
    }
}