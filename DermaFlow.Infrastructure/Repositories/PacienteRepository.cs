using DermaFlow.Domain.Entities;
using DermaFlow.Application.Interfaces;
using DermaFlow.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DermaFlow.Infrastructure.Repositories;

public class PacienteRepository : IPacienteRepository
{
    private readonly DermaFlowDbContext _context;

    public PacienteRepository(DermaFlowDbContext context)
    {
        _context = context;
    }

    public async Task<Paciente?> ObterPorIdAsync(Guid id, CancellationToken ct)
    {
        return await _context.Pacientes.FindAsync(new object[] { id }, ct);
    }

    public async Task<Guid> AdicionarAsync(Paciente paciente, CancellationToken ct)
    {
        await _context.Pacientes.AddAsync(paciente, ct);
        await _context.SaveChangesAsync(ct);
        return paciente.Id;
    }

  public async Task<List<Paciente>> ListarTodosAsync(CancellationToken ct)
    {
        return await _context.Pacientes
                            .AsNoTracking()
                            .ToListAsync(ct);
    }
}