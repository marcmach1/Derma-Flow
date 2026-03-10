using DermaFlow.Application.Users.Commands;
using DermaFlow.Shared.DTOs;
using MediatR;

namespace DermaFlow.API.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/users");

        group.MapPost("/", async (UserRequestDTO request, IMediator mediator) =>
        {
            var command = new CreateUserCommand(request.Name, request.Email, request.Password);
            var userId = await mediator.Send(command);
            
            return Results.Created($"/users/{userId}", new { id = userId });
        });
        
        // No futuro, você adiciona o Get, Put e Delete aqui dentro do group!
    }
}