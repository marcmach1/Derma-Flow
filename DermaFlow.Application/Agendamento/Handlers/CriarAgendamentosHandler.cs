using MediatR;
using DermaFlow.Application.Interfaces;
using DermaFlow.Domain.Entities;
using DermaFlow.Application.Agendamentos.Commands;

namespace DermaFlow.Application.Agendamentos.Commands;

// REGRA DO GERSON: Deve ser PUBLIC e ter os dois tipos <Comando, Retorno>
public class CriarAgendamentoHandler : IRequestHandler<CriarAgendamentoCommand, Guid>
{
    private readonly IAgendamentoRepository _repository;

    public CriarAgendamentoHandler(IAgendamentoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CriarAgendamentoCommand request, CancellationToken ct)
    {
        var dataUtc = DateTime.SpecifyKind(request.DataHora, DateTimeKind.Utc);

        // Agora passamos a dataUtc ajustada
        var agendamento = new Agendamento(
            request.ClinicId, 
            request.PacienteId, 
            dataUtc, 
            request.Observacoes
        );
        await _repository.AdicionarAsync(agendamento);
        return agendamento.Id;
    }
}