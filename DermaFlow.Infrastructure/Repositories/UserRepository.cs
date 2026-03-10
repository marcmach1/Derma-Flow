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

    // 1. Adicionamos o 'CancellationToken ct' para bater com a Interface
    public async Task<User?> ObterPorIdAsync(Guid id, CancellationToken ct)
    {
        return await _context.Users.FindAsync(new object[] { id }, ct);
    }

    // 2. Mudamos para 'AdicionarAsync' e incluímos o 'ct'
    public async Task<Guid> AdicionarAsync(User user, CancellationToken ct)
    {
        await _context.Users.AddAsync(user, ct);
        await _context.SaveChangesAsync(ct);
        return user.Id;
    }
}