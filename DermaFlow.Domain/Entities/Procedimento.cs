namespace DermaFlow.Domain.Entities;

public class Procedimento
{
    public Guid Id { get; set; }
    public Guid? ClinicId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int DuracaoMinutos { get; set; } = 15; // Onde a mágica dos 15 min acontece
}