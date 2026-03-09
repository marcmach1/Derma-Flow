using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration; // Já deve estar aí
using System.IO;

namespace DermaFlow.Infrastructure.Context;

public class DesignDbContextFactory : IDesignTimeDbContextFactory<DermaFlowDbContext>
{
    public DermaFlowDbContext CreateDbContext(string[] args)
    {
        // Busca o appsettings.json dentro da API para pegar a connection string
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../DermaFlow.API"))
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<DermaFlowDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseNpgsql(connectionString);

        return new DermaFlowDbContext(builder.Options);
    }
}