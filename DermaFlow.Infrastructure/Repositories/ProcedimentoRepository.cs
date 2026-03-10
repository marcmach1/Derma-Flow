using DermaFlow.Domain.Entities;
using DermaFlow.Application.Interfaces;
using DermaFlow.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DermaFlow.Infrastructure.Repositories;

public class ProcedimentoRepository : IProcedimentoRepository
{
    // 1. A "gaveta" onde guardamos o acesso ao banco
    private readonly DermaFlowDbContext _context;

    // 2. O construtor que recebe o banco do ASP.NET Core
    public ProcedimentoRepository(DermaFlowDbContext context)
    {
        _context = context;
    }

    // 3. O método que você já tinha
    public async Task<Guid> AdicionarAsync(Procedimento procedimento, CancellationToken ct)
    {
        await _context.Procedimentos.AddAsync(procedimento, ct);
        await _context.SaveChangesAsync(ct);
        return procedimento.Id;
    }

    // 4. O método novo para o Agendamento (Busca)
    public async Task<Procedimento?> ObterPorIdAsync(Guid id, CancellationToken ct)
    {
        return await _context.Procedimentos.FindAsync(new object[] { id }, ct);
    }

    // 5. O método novo para a Tela (Listagem)
    public async Task<IEnumerable<Procedimento>> ListarTodosAsync(CancellationToken ct)
    {
        return await _context.Procedimentos.ToListAsync(ct);
    }
}