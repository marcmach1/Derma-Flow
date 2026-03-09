 using DermaFlow.Domain.Entities;
using DermaFlow.Application.Interfaces; // Para enxergar a Interface que movemos para Application
using DermaFlow.Infrastructure.Context; // <--- ADICIONE ESTA LINHA
using Microsoft.EntityFrameworkCore;

namespace DermaFlow.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DermaFlowDbContext _context; // Agora ele vai encontrar o nome

    public UserRepository(DermaFlowDbContext context)
    {
        _context = context;
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