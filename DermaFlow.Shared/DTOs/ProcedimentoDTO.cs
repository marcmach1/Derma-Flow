namespace DermaFlow.Shared.DTOs;

public class ProcedimentoDTO
{
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int DuracaoMinutos { get; set; }
    public Guid ClinicId { get; set; }
}