using DermaFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DermaFlow.Infrastructure.Context;

public class DermaFlowDbContext : DbContext
{
    public DermaFlowDbContext(DbContextOptions<DermaFlowDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Agendamento> Agendamentos { get; set; }
    public DbSet<Procedimento> Procedimentos { get; set; }
    public DbSet<Paciente> Pacientes { get; set; } // <--- ADICIONE ESTE

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuração de Usuário
        modelBuilder.Entity<User>(entity => {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
            entity.Property(e => e.Password).IsRequired();
        });

        // Configuração de Agendamento
        modelBuilder.Entity<Agendamento>(entity => {
            entity.HasKey(e => e.Id);
            
            // Relacionamento Muitos-para-Muitos (A mágica da tabela de ligação)
            entity.HasMany(a => a.Procedimentos)
                  .WithMany(); 
            
            // Relacionamento com Paciente
            entity.HasOne(a => a.Paciente)
                  .WithMany(p => p.Agendamentos)
                  .HasForeignKey(a => a.PacienteId);
        });

        // Configuração de Paciente
        modelBuilder.Entity<Paciente>(entity => {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.ClinicId); // Index para performance no Multi-clínica
        });

        // Configuração de Procedimento
        modelBuilder.Entity<Procedimento>(entity => {
            entity.HasKey(e => e.Id);
        });

        base.OnModelCreating(modelBuilder);
    }
}