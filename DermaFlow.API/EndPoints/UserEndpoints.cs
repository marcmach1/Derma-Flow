using DermaFlow.Application.Users.Commands;
using DermaFlow.Application.Interfaces; // Para acessar o IUserRepository
using DermaFlow.Shared.DTOs;
using MediatR;

namespace DermaFlow.API.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        // Adicionando o v1 para bater com a chamada do Blazor
        var group = app.MapGroup("/v1/users");

        // POST - Criar Usuário
        group.MapPost("/", async (UserRequestDTO request, IMediator mediator) =>
        {
            var command = new CreateUserCommand(request.Name, request.Email, request.Password);
            var userId = await mediator.Send(command);
            
            return Results.Created($"/v1/users/{userId}", new { id = userId });
        });

        // GET - Listar Usuários (O que a tela de agendamento precisa)
        group.MapGet("/", async (IUserRepository repo) =>
        {
            var users = await repo.ListarTodosAsync(default);
            
            // Mapeando para o DTO que agora tem ID (conforme conversamos)
            var response = users.Select(u => new UserRequestDTO 
            { 
                Id = u.Id, 
                Name = u.Name, 
                Email = u.Email 
            });

            return Results.Ok(response);
        });
    }
}