using DermaFlow.Domain.Entities;
using DermaFlow.Application.Interfaces;
using DermaFlow.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DermaFlow.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DermaFlowDbContext _context;

    public UserRepository(DermaFlowDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }
   
    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}