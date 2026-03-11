namespace DermaFlow.Application.Interfaces;
using DermaFlow.Domain.Entities;

public interface IPacienteRepository
{
    Task<Guid> AdicionarAsync(Paciente paciente, CancellationToken ct);
    Task<List<Paciente>> ListarTodosAsync(CancellationToken ct);
}