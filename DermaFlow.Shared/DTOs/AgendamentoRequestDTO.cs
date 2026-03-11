namespace DermaFlow.Shared.DTOs;

public class AgendamentoRequestDTO
{
    public Guid ClinicId { get; set; }
    public Guid PacienteId { get; set; }
    public DateTime DataHora { get; set; }
    public string? Observacoes { get; set; }
    
    // Lista de IDs dos procedimentos selecionados no DropDown do Radzen
    public List<Guid> ProcedimentoIds { get; set; } = new();
}