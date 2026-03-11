using MediatR;
using DermaFlow.Application.Interfaces;
using DermaFlow.Domain.Entities;
using DermaFlow.Application.Agendamentos.Commands;

namespace DermaFlow.Application.Agendamentos.Commands;

public class CriarAgendamentoHandler : IRequestHandler<CriarAgendamentoCommand, Guid>
{
    private readonly IAgendamentoRepository _repository;
    private readonly IProcedimentoRepository _procedimentoRepository; // 1. Injetamos o repositório de procedimentos

    public CriarAgendamentoHandler(IAgendamentoRepository repository, IProcedimentoRepository procedimentoRepository)
    {
        _repository = repository;
        _procedimentoRepository = procedimentoRepository;
    }

    public async Task<Guid> Handle(CriarAgendamentoCommand request, CancellationToken ct)
    {
        // Ajuste de fuso horário para o Postgres
        var dataUtc = DateTime.SpecifyKind(request.DataHora, DateTimeKind.Utc);

        // 2. Criamos a entidade
        var agendamento = new Agendamento(
            request.ClinicId, 
            request.PacienteId, 
            dataUtc, 
            request.Observacoes
        );

        // 3. A MÁGICA: Buscamos cada procedimento e adicionamos na entidade
        // Isso fará o EF Core preencher a tabela AgendamentoProcedimento
        if (request.ProcedimentoIds != null && request.ProcedimentoIds.Any())
        {
            foreach (var id in request.ProcedimentoIds)
            {
                var procedimento = await _procedimentoRepository.ObterPorIdAsync(id, ct);
                if (procedimento != null)
                {
                    agendamento.AdicionarProcedimento(procedimento);
                }
            }
        }

        // 4. Salva o agendamento E as relações na tabela intermediária
        await _repository.AdicionarAsync(agendamento);
        
        return agendamento.Id;
    }
}