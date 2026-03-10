namespace DermaFlow.Application.Interfaces;
using DermaFlow.Domain.Entities;

public interface IAgendamentoRepository
{
    Task<Guid> AdicionarAsync(Agendamento agendamento, CancellationToken ct);
}