using DermaFlow.Application.Interfaces;
using DermaFlow.Domain.Entities;
using DermaFlow.Infrastructure.Context;


namespace DermaFlow.Infrastructure.Repositories;

public class AgendamentoRepository : IAgendamentoRepository
{
    private readonly DermaFlowDbContext _context;

    public AgendamentoRepository(DermaFlowDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> AdicionarAsync(Agendamento agendamento, CancellationToken ct)
    {
        await _context.Agendamentos.AddAsync(agendamento, ct);
        await _context.SaveChangesAsync(ct);
        return agendamento.Id;
    }
}