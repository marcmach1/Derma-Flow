using DermaFlow.Shared.DTOs;
using MediatR;
using DermaFlow.Application.Agendamentos.Commands;
using DermaFlow.Application.Agendamentos.Queries; // Vamos criar isso agora

namespace DermaFlow.API.EndPoints;

public static class AgendamentoEndpoints
{
    public static void MapAgendamentoEndpoints(this WebApplication app)
    {
        // POST - Cadastrar Agendamento
        app.MapPost("/v1/agendamentos", async (AgendamentoRequestDTO dto, IMediator mediator) =>
        {
            var command = new CriarAgendamentoCommand(
                dto.ClinicId,
                dto.PacienteId,
                dto.DataHora,
                dto.ProcedimentoIds,
                dto.Observacoes
            );

            var result = await mediator.Send(command);
            return Results.Created($"/v1/agendamentos/{result}", result);
        });

        // GET - Listar Agendamentos (Para o seu Grid lateral)
        app.MapGet("/v1/agendamentos", async (IMediator mediator) =>
        {
            var query = new ObterAgendamentosQuery(); 
            var result = await mediator.Send(query);
            return Results.Ok(result);
        });
    }
}