using DermaFlow.Application.Procedimentos.Commands;
using DermaFlow.Shared.DTOs;
using MediatR;
using DermaFlow.Application.Interfaces; // <-- Importante para o IProcedimentoRepository

namespace DermaFlow.API.EndPoints;

public static class ProcedimentoEndpoints
{
    public static void MapProcedimentoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/v1/procedimentos");

        // ROTA DE CRIAÇÃO (POST)
        group.MapPost("/", async (ProcedimentoDTO dto, IMediator mediator) =>
        {
            var command = new CriarProcedimentoCommand(
                dto.Nome, 
                dto.Preco, 
                dto.DuracaoMinutos,
                dto.ClinicId
            );

            var id = await mediator.Send(command);
            return Results.Created($"/v1/procedimentos/{id}", new { id });
        });

        // ROTA DE LISTAGEM (GET) - É AQUI QUE O CÓDIGO VAI!
        group.MapGet("/", async (IProcedimentoRepository repo, CancellationToken ct) => 
        {
            var procedimentos = await repo.ListarTodosAsync(ct);
            
            var response = procedimentos.Select(p => new ProcedimentoDTO 
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco,
                DuracaoMinutos = p.DuracaoMinutos,
                ClinicId = p.ClinicId ?? Guid.Empty
            });

            return Results.Ok(response); 
        });
    }
}