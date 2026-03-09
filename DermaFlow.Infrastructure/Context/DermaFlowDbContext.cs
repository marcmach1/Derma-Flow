using DermaFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DermaFlow.Infrastructure.Context;

public class DermaFlowDbContext : DbContext
{
    public DermaFlowDbContext(DbContextOptions<DermaFlowDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Agendamento> Agendamentos { get; set; }
    public DbSet<Procedimento> Procedimentos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurações do User (Conforme solicitado: Nome, Telefone e Id)
        modelBuilder.Entity<User>(entity => {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Telefone).HasMaxLength(20);
        });

        // Configurações do Agendamento
        modelBuilder.Entity<Agendamento>(entity => {
            entity.HasKey(e => e.Id);
        });

        base.OnModelCreating(modelBuilder);
    }
}