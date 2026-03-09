namespace DermaFlow.Domain.Entities;

public class Procedimento
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
}