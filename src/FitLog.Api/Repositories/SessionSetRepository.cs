using FitLog.Api.Data;
using FitLog.Api.Entities;
using FitLog.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitLog.Api.Repositories;

public class SessionSetRepository: ISessionSetRepository
{
    private readonly FitLogDbContext _context;
    
    public SessionSetRepository(FitLogDbContext context)
    {
        _context = context;
    }


    public Task<bool> ExistsAsync(int sessionExerciseId, int setNumber)
    {
        return _context.SessionSets.
            AnyAsync(x=>x.SessionExerciseId == sessionExerciseId && x.SetNumber == setNumber);
        
        
    }

    public Task AddAsync(SessionSet sessionSet)
    {
        _context.SessionSets.Add(sessionSet);
        return _context.SaveChangesAsync();
    }
}