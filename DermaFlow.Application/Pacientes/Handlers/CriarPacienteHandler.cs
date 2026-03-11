using DermaFlow.Domain.Entities;
using DermaFlow.Application.Interfaces; // <-- Onde está sua IProcedimentoRepository
using MediatR;
using DermaFlow.Application.Pacientes.Commands;

public class CriarPacienteHandler(IPacienteRepository repository) 
    : IRequestHandler<CriarPacienteCommand, Guid>
{
    public async Task<Guid> Handle(CriarPacienteCommand request, CancellationToken ct)
    {
        var paciente = new Paciente {
            Nome = request.Nome,
            Cpf = request.Cpf,
            Telefone = request.Telefone,
            Email = request.Email,
            ClinicId = request.ClinicId
        };

        return await repository.AdicionarAsync(paciente, ct);
    }
}