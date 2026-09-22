using FitLog.Api.Dtos;
using FitLog.Api.Entities;
using FitLog.Api.Enum;
using FitLog.Api.Interfaces;
using FitLog.Api.Repositories;

namespace FitLog.Api.Services;

public class WorkoutService:IWorkoutService
{
    private readonly IWorkoutRepository _workoutRepository;
    private readonly IExerciseRepository _exerciseRepository;
    
    public WorkoutService(IExerciseRepository exerciseRepository,IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
        _exerciseRepository = exerciseRepository;
    }
    
    public async Task CreateWorkoutAsync(WorkoutDto dto)
    {
        Workout workout = new Workout
        {
            Name = dto.Name,
            Description = dto.Description,
            WorkoutDate = dto.WorkoutDate
        };

       await _workoutRepository.WorkoutCreateAsync(workout);
    }

    public async Task<List<WorkoutDto>> GetAllWorkoutsAsync()
    {
        List<Workout> workouts = await _workoutRepository.GetAllWorkoutsAsync();

        List<WorkoutDto> workoutDtos = workouts.Select(p => new WorkoutDto
        {
            Name = p.Name,
            Description = p.Description,
            WorkoutDate = p.WorkoutDate
        }).ToList();
        
        return workoutDtos;
    }

    public async Task<WorkoutDto?> GetWorkoutByIdAsync(int id)
    {
        Workout? workout = await _workoutRepository.GetWorkoutByIdAsync(id);

        if (workout is null)
        {
            return null;
        }

        WorkoutDto workoutDto = new WorkoutDto
        {
            Name = workout.Name,
            Description = workout.Description,
            WorkoutDate = workout.WorkoutDate
        };

        return workoutDto;
    }

    public async Task<bool> UpdateWorkoutAsync(int id,UpdateWorkoutDto updateWorkoutDto)
    {
        Workout? workout = await _workoutRepository.GetWorkoutByIdAsync(id);

        if (workout is null)
        {
            return false;
        }
        
        workout.Name=updateWorkoutDto.Name;
        workout.Description = updateWorkoutDto.Description;
        workout.WorkoutDate = updateWorkoutDto.WorkoutDate;

        _workoutRepository.UpdateWorkoutAsync(workout);
        return true;
    }

    public async Task<bool> DeleteWorkoutAsync(int id)
    {
        Workout? workout = await _workoutRepository.GetWorkoutByIdAsync(id);

        if (workout is null)
        {
            return false;
        }
        
       await _workoutRepository.DeleteWorkoutAsync(workout);
        return true;
    }

    public async Task<AddExerciseToWorkoutResult> CreateWorkoutExerciseAsync(
        int workoutId,
        AddExerciseToWorkoutDto addExerciseToWorkoutDto)
    {
        Workout? workout =
            await _workoutRepository.GetWorkoutByIdAsync(workoutId);

        if (workout is null)
        {
            return AddExerciseToWorkoutResult.WorkoutNotFound;
        }

        Exercise? exercise =
            await _exerciseRepository.GetExerciseAsync(
                addExerciseToWorkoutDto.ExerciseId);

        if (exercise is null)
        {
            return AddExerciseToWorkoutResult.ExerciseNotFound;
        }
       
        bool alreadyExists =
            await _workoutRepository.WorkoutExerciseExistsAsync(
                workoutId,
                addExerciseToWorkoutDto.ExerciseId);

        if (alreadyExists)
        {
            return AddExerciseToWorkoutResult.AlreadyExists;
        }
        
        WorkoutExercise workoutExercise = new WorkoutExercise
        {
            WorkoutId = workout.Id,
            ExerciseId = exercise.Id,
            Weight = addExerciseToWorkoutDto.Weight,
            RepetitionCount = addExerciseToWorkoutDto.RepetitionCount,
            SetCount = addExerciseToWorkoutDto.SetCount
        };

        await _workoutRepository.AddWorkoutExerciseAsync(workoutExercise);

        return AddExerciseToWorkoutResult.Success;
    }
    public async Task<List<WorkoutExerciseDto>?> GetWorkoutExercisesAsync(int workoutId)
    {
        Workout? workout =
            await _workoutRepository.GetWorkoutByIdAsync(workoutId);

        if (workout is null)
        {
            return null;
        }

        List<WorkoutExercise> workoutExercises =
            await _workoutRepository.GetWorkoutExercisesAsync(workoutId);

        List<WorkoutExerciseDto> workoutExerciseDtos =
            workoutExercises.Select(x => new WorkoutExerciseDto
            {
                ExerciseId = x.ExerciseId,
                ExerciseName = x.Exercise.Name,
                Weight = x.Weight,
                RepetitionCount = x.RepetitionCount,
                SetCount = x.SetCount
            }).ToList();

        return workoutExerciseDtos;
    }
}