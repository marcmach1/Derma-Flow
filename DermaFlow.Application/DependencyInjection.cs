// Local: DermaFlow.Application/DependencyInjection.cs
using Microsoft.Extensions.DependencyInjection;

namespace DermaFlow.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => 
        {
            // Agora a Application registra a SI MESMA
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });

        return services;
    }
}