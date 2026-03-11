using DermaFlow.Shared.DTOs;
using MediatR;

namespace DermaFlow.Application.Agendamentos.Queries;

// O Record é perfeito para Queries pois é imutável
public record ObterAgendamentosQuery : IRequest<List<AgendamentoResponseDTO>>;