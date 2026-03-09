using DermaFlow.Application.Users.Commands;
using DermaFlow.Infrastructure.IoC;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Configura o banco e repositórios (IoC)
builder.Services.AddInfrastructure(builder.Configuration);

// Configura o MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUserCommand).Assembly));

var app = builder.Build();

// O endpoint que você pediu
app.MapPost("/users", async (CreateUserCommand command, IMediator mediator) =>
{
    var userId = await mediator.Send(command);
    return Results.Created($"/users/{userId}", new { id = userId });
});

app.Run();