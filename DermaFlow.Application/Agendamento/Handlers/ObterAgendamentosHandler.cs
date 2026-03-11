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
        // Busca os dados via Repository (que está na Infrastructure)
        var agendamentos = await _repository.ListarTodosComPacientesAsync();

        // Mapeia para o DTO que o Blazor espera
        return agendamentos.Select(a => new AgendamentoResponseDTO
        {
            Id = a.Id,
            DataHora = a.DataHora,
            PacienteNome = a.Paciente?.Nome ?? "Paciente não identificado",
            Status = "Agendado"
        }).ToList();
    }
}