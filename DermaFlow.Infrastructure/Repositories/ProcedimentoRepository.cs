using DermaFlow.Application.Interfaces;
using DermaFlow.Domain.Entities;
using DermaFlow.Infrastructure.Context;

namespace DermaFlow.Infrastructure.Repositories; // <-- ESTE NOME É VITAL

public class ProcedimentoRepository : IProcedimentoRepository
{
    private readonly DermaFlowDbContext _context;

    public ProcedimentoRepository(DermaFlowDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> AdicionarAsync(Procedimento procedimento, CancellationToken ct)
    {
        _context.Procedimentos.Add(procedimento);
        await _context.SaveChangesAsync(ct);
        return procedimento.Id;
    }
}