using MediatR;

namespace DermaFlow.Application.Procedimentos.Commands; // <--- TEM QUE SER IGUAL AO DO HANDLER

public record CriarProcedimentoCommand(
    string Nome, 
    decimal Preco, 
    int DuracaoMinutos, 
    Guid ClinicId
) : IRequest<Guid>;