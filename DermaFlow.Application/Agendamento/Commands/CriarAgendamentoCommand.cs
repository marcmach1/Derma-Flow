using MediatR;

namespace DermaFlow.Application.Agendamentos.Commands;

// O IRequest<Guid> diz ao MediatR que, ao terminar, ele devolve o ID do agendamento criado.
public record CriarAgendamentoCommand(
    Guid ClinicId,
    Guid PacienteId,
    DateTime DataHora,
    List<Guid> ProcedimentoIds, // Lista de IDs pois um agendamento pode ter vários procedimentos
    string? Observacoes = null
) : IRequest<Guid>
{
    // Construtor vazio para o Blazor/Serialização JSON não reclamar
    public CriarAgendamentoCommand() : this(Guid.Empty, Guid.Empty, DateTime.Now, new List<Guid>()) {}
}