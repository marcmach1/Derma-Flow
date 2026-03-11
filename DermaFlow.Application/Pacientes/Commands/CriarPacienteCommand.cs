using MediatR;
namespace DermaFlow.Application.Pacientes.Commands;

public record CriarPacienteCommand(
    string Nome, 
    string Cpf, 
    string Telefone, 
    string Email, 
    Guid ClinicId) : IRequest<Guid>;