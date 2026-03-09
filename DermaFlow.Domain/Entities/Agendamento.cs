using DermaFlow.Shared.Enums;
namespace DermaFlow.Domain.Entities;


public class Agendamento
{
    public Guid Id { get; private set; }
    public Guid ClienteId { get; private set; }
    public DateTime DataHora { get; private set; }
    public StatusAgendamento Status { get; private set; }
    public string? Observacoes { get; private set; }

    

    // Construtor para o EF Core
    protected Agendamento() { }

    public Agendamento(Guid clienteId, DateTime dataHora)
    {
        if (dataHora < DateTime.Now)
            throw new ArgumentException("Não é possível agendar no passado.");

        Id = Guid.NewGuid();
        ClienteId = clienteId;
        DataHora = dataHora;
        Status = StatusAgendamento.Agendado;
    }

    public void ConfirmarPresenca() => Status = StatusAgendamento.Confirmado;
    
    public void MarcarComoConcluido() 
    {
        Status = StatusAgendamento.Concluido;
        // Aqui poderíamos disparar um Domain Event para o n8n futuramente
    }
}