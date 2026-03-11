using DermaFlow.Domain.Entities;
using DermaFlow.Application.Interfaces;
using DermaFlow.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

public class AgendamentoRepository : IAgendamentoRepository
{
    private readonly DermaFlowDbContext _context;
    public AgendamentoRepository(DermaFlowDbContext context) => _context = context;

    public async Task AdicionarAsync(Agendamento agendamento) 
    {
        await _context.Agendamentos.AddAsync(agendamento);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Agendamento>> ListarTodosComPacientesAsync()
    {
        return await _context.Agendamentos
            .Include(a => a.Paciente)
            .Include(a => a.Procedimentos) // Tenta carregar a lista diretamente
            .AsNoTracking()
            .OrderByDescending(a => a.DataHora)
            .ToListAsync();
    }
}