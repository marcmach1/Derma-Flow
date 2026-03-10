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
       
        modelBuilder.Entity<User>(entity => {
            entity.HasKey(e => e.Id);
           
            entity.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.Email)
                  .IsRequired()
                  .HasMaxLength(150);

            entity.Property(e => e.Password)
                  .IsRequired();
        });

        modelBuilder.Entity<Agendamento>(entity => {
            entity.HasKey(e => e.Id);
        });

        base.OnModelCreating(modelBuilder);
    }
}