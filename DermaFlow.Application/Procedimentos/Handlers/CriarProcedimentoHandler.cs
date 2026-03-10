using DermaFlow.Domain.Entities;
using DermaFlow.Application.Interfaces; // <-- Onde está sua IProcedimentoRepository
using MediatR;
using DermaFlow.Application.Procedimentos.Commands;

namespace DermaFlow.Application.Procedimentos.Handlers;

public class CriarProcedimentoHandler : IRequestHandler<CriarProcedimentoCommand, Guid>
{
    // Trocamos o DbContext pela Interface
    private readonly IProcedimentoRepository _repository;

    public CriarProcedimentoHandler(IProcedimentoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CriarProcedimentoCommand request, CancellationToken ct)
    {
        var procedimento = new Procedimento
        {
            Id = Guid.NewGuid(),
            Nome = request.Nome,
            Preco = request.Preco,
            DuracaoMinutos = request.DuracaoMinutos,
            ClinicId = request.ClinicId
        };

        // O Repositório (lá na Infrastructure) é quem vai saber usar o DbContext
        return await _repository.AdicionarAsync(procedimento, ct);
    }
}