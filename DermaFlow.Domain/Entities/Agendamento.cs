using DermaFlow.Shared.Enums;

namespace DermaFlow.Domain.Entities;

public class Agendamento
{
    public Guid Id { get; private set; }
    public Guid ClinicId { get; private set; } 
    public Guid PacienteId { get; private set; } 
    
    // 1. Verifique se o nome é Paciente (em português) e se é PUBLIC
    public Paciente Paciente { get; private set; } = null!;
    
    public DateTime DataHora { get; private set; }
    public DateTime DataHoraFim { get; private set; } 
    
    public StatusAgendamento Status { get; private set; }
    public string? Observacoes { get; private set; }

    // 2. Verifique se a lista é Procedimentos (em português) e se é PUBLIC
    private readonly List<Procedimento> _procedimentos = new();
    public ICollection<Procedimento> Procedimentos => _procedimentos.AsReadOnly();

    protected Agendamento() { }

    public Agendamento(Guid clinicId, Guid pacienteId, DateTime dataHora, string? observacoes)
    {
        Id = Guid.NewGuid();
        ClinicId = clinicId;
        PacienteId = pacienteId;
        DataHora = dataHora;
        Observacoes = observacoes; // <--- Adicione esta linha
        Status = StatusAgendamento.Agendado;
    }

    public void AdicionarProcedimento(Procedimento procedimento)
    {
        _procedimentos.Add(procedimento);
        RecalcularHorarioFim();
    }

    private void RecalcularHorarioFim()
    {
        var minutosTotais = _procedimentos.Sum(p => p.DuracaoMinutos);
        DataHoraFim = DataHora.AddMinutes(minutosTotais);
    }
}