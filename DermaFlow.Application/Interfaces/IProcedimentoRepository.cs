namespace DermaFlow.Application.Interfaces;
using DermaFlow.Domain.Entities;


public interface IProcedimentoRepository
{
    Task<Guid> AdicionarAsync(Procedimento procedimento, CancellationToken ct);
    // Outros métodos como BuscarPorId, Listar, etc.
}