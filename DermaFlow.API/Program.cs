using DermaFlow.Application.Users.Commands;
using DermaFlow.Infrastructure.IoC;
using MediatR;
using DermaFlow.Shared.DTOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddMediatR(cfg => 
{
    cfg.RegisterServicesFromAssembly(typeof(DermaFlow.Application.Users.Commands.CreateUserCommand).Assembly);
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


    app.MapPost("/users", async (UserRequestDTO request, IMediator mediator) =>
    {
        var command = new CreateUserCommand(request.Name, request.Email, request.Password);
        var userId = await mediator.Send(command);
        
        return Results.Created($"/users/{userId}", new { id = userId });
    });

app.Run();