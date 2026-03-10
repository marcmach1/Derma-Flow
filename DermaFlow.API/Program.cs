using DermaFlow.Infrastructure.IoC;
using DermaFlow.Application;
using DermaFlow.API.Endpoints; // Certifique-se de importar o namespace das extensões

var builder = WebApplication.CreateBuilder(args);

// 1. Injeção de Dependência por Camada
builder.Services.AddCors(options => {
    options.AddPolicy("PermitirBlazor", policy => 
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

// 2. Middlewares
app.UseCors("PermitirBlazor");
app.UseSwagger();
app.UseSwaggerUI();

// 3. Onde a "mágica" modular acontece
// A API agora apenas "habilita" os módulos de endpoints
app.MapUserEndpoints();
app.MapProcedimentoEndpoints();

app.Run("http://localhost:5253");