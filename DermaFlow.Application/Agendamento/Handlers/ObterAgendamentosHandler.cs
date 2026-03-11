using DermaFlow.Application.Interfaces;
using DermaFlow.Shared.DTOs;
using MediatR;

namespace DermaFlow.Application.Agendamentos.Queries;

public class ObterAgendamentosHandler : IRequestHandler<ObterAgendamentosQuery, List<AgendamentoResponseDTO>>
{
    private readonly IAgendamentoRepository _repository;

    public ObterAgendamentosHandler(IAgendamentoRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<AgendamentoResponseDTO>> Handle(ObterAgendamentosQuery request, CancellationToken ct)
    {
        var agendamentos = await _repository.ListarTodosComPacientesAsync();

        return agendamentos.Select(a => new AgendamentoResponseDTO
        {
            Id = a.Id,
            DataHora = a.DataHora,
            PacienteNome = a.Paciente?.Nome ?? "N/A",
            Status = "Agendado", 
            
            ProcedimentoNomes = a.Procedimentos != null && a.Procedimentos.Any()
                ? string.Join(", ", a.Procedimentos.Select(p => p.Nome))
                : "Nenhum"
        }).ToList();
    }
}