namespace DermaFlow.Application.Interfaces;
using DermaFlow.Domain.Entities;

public interface IProcedimentoRepository
{
    Task<Guid> AdicionarAsync(Procedimento procedimento, CancellationToken ct);
    
    // Essencial para o Handler de Agendamento funcionar:
    Task<Procedimento?> ObterPorIdAsync(Guid id, CancellationToken ct);
    
    // Essencial para o DropDown da tela de Agendamento:
    Task<IEnumerable<Procedimento>> ListarTodosAsync(CancellationToken ct);
}