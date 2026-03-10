namespace DermaFlow.Domain.Entities;

public class Paciente
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ClinicId { get; set; } // Essencial para o Multi-clínica
    public string Nome { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    // Relacionamento: Um paciente pode ter vários agendamentos
    public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
}