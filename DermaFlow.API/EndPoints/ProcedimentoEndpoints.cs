using DermaFlow.Application.Procedimentos.Commands;
using DermaFlow.Shared.DTOs;
using MediatR;

// 1. Verifique se o namespace é este:
namespace DermaFlow.API.Endpoints; 

public static class ProcedimentoEndpoints
{
    // 2. O método PRECISA ser static e ter o "this IEndpointRouteBuilder"
    public static void MapProcedimentoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/procedimentos");

        group.MapPost("/", async (ProcedimentoDTO dto, IMediator mediator) =>
        {
            var command = new CriarProcedimentoCommand(
                dto.Nome, 
                dto.Preco, 
                dto.DuracaoMinutos, 
                dto.ClinicId
            );

            var id = await mediator.Send(command);
            return Results.Created($"/api/procedimentos/{id}", new { id });
        });
    }
}