using DermaFlow.Application.Interfaces;
using DermaFlow.Infrastructure.Context;
using DermaFlow.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DermaFlow.Infrastructure.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Configuração Postgres (Railway)
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<DermaFlowDbContext>(options =>
            options.UseNpgsql(connectionString));

        // Repositórios
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IProcedimentoRepository, ProcedimentoRepository>();

        return services;
    }
}