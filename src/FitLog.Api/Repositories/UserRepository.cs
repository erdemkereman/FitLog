using FitLog.Api.Data;
using FitLog.Api.Entities;
using FitLog.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitLog.Api.Repositories;

public class UserRepository:IUserRepository
{
    public FitLogDbContext _context;
    public UserRepository(FitLogDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x=>x.Id==id);
        return user;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        var user=await _context.Users.FirstOrDefaultAsync(x=>x.Email==email);
        return user;
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x=>x.Username==username);
        return user;
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }
}