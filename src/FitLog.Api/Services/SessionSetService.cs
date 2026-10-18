using FitLog.Api.Data;
using FitLog.Api.Dtos;
using FitLog.Api.Entities;
using FitLog.Api.Enums;
using FitLog.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitLog.Api.Services;

public class SessionSetService:ISessionSetService
{
    private readonly ISessionSetRepository _repository;
    private readonly FitLogDbContext  _context;

    public SessionSetService(ISessionSetRepository  repository, FitLogDbContext context)
    {
        _repository = repository;
        _context = context;
    }
    
    public async Task<AddSessionSetResult> AddSessionSetAsync(int sessionExerciseId, CreateSessionSetDto dto)
    {
        bool sessionExerciseExists = await _context.SessionExercises
            .AnyAsync(x => x.Id == sessionExerciseId);

        if (sessionExerciseExists is false)
        {
            return AddSessionSetResult.SessionExerciseNotFound;
        }
        if (dto.SetNumber <= 0 ||
            dto.Weight < 0 ||
            dto.RepetitionCount <= 0)
        {
            return AddSessionSetResult.InvalidSetData;
        }

       
        bool alreadyExists = await _repository.ExistsAsync(
            sessionExerciseId,
            dto.SetNumber);

        if (alreadyExists)
        {
            return AddSessionSetResult.AlreadyExists;
        }

        
        SessionSet sessionSet = new SessionSet
        {
            SessionExerciseId = sessionExerciseId,
            SetNumber = dto.SetNumber,
            Weight = dto.Weight,
            RepetitionCount = dto.RepetitionCount
        };
        
        await _repository.AddAsync(sessionSet);

        return AddSessionSetResult.Success;
    }
}