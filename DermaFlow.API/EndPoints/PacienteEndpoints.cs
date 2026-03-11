using DermaFlow.Shared.DTOs;
using MediatR;
using DermaFlow.Application.Pacientes.Commands;
using DermaFlow.Application.Interfaces; // <-- Adicione esta linha

namespace DermaFlow.API.EndPoints;

// O ERRO ESTAVA AQUI: Faltava envolver o método nesta classe estática
public static class PacienteEndpoints 
{
    public static void MapPacienteEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/v1/pacientes");

        group.MapPost("/", async (PacienteDTO dto, IMediator mediator) => 
        {
            var cmd = new CriarPacienteCommand(dto.Nome, dto.Cpf, dto.Telefone, dto.Email, dto.ClinicId);
            var id = await mediator.Send(cmd);
            return Results.Created($"/v1/pacientes/{id}", new { id });
        });

        group.MapGet("/", async (IPacienteRepository repo, CancellationToken ct) => 
        {
            var pacientes = await repo.ListarTodosAsync(ct);
            return Results.Ok(pacientes);
        });
    }
}