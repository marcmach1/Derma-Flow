using DermaFlow.Application.Agendamentos.Commands;
using DermaFlow.Domain.Entities;
using DermaFlow.Application.Interfaces; // Onde estarão as interfaces
using MediatR;

namespace DermaFlow.Application.Agendamentos.Handlers;

public class CriarAgendamentoHandler : IRequestHandler<CriarAgendamentoCommand, Guid>
{
    private readonly IAgendamentoRepository _agendamentoRepository;
    private readonly IProcedimentoRepository _procedimentoRepository;

    // Precisamos dos dois repositórios: um para salvar e outro para buscar os procedimentos
    public CriarAgendamentoHandler(
        IAgendamentoRepository agendamentoRepository, 
        IProcedimentoRepository procedimentoRepository)
    {
        _agendamentoRepository = agendamentoRepository;
        _procedimentoRepository = procedimentoRepository;
    }

    public async Task<Guid> Handle(CriarAgendamentoCommand request, CancellationToken ct)
    {
        // 1. Instancia a Entidade Rica (usando o construtor que você criou)
        var agendamento = new Agendamento(
            request.ClinicId, 
            request.PacienteId, 
            request.DataHora
        );

        // 2. Busca cada procedimento no banco e adiciona na entidade
        // Isso garante que a DataHoraFim seja calculada com dados reais
        foreach (var procId in request.ProcedimentoIds)
        {
            var proc = await _procedimentoRepository.ObterPorIdAsync(procId, ct);
            if (proc != null)
            {
                agendamento.AdicionarProcedimento(proc);
            }
        }

        // 3. Persistência via Repositório
        return await _agendamentoRepository.AdicionarAsync(agendamento, ct);
    }
}