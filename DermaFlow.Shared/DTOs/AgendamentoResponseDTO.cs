namespace DermaFlow.Shared.DTOs;

public class AgendamentoResponseDTO
{
    public Guid Id { get; set; }
    public DateTime DataHora { get; set; }
    
    // Aqui está o segredo: a API vai preencher o Nome para o Grid mostrar
    public string PacienteNome { get; set; } = string.Empty;
    
    public string? Observacoes { get; set; }
    public string Status { get; set; } = "Agendado";
    public string ProcedimentoNomes { get; set; } = string.Empty;
}