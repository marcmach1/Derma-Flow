using MediatR; // <-- VITAL: Adicione este using

namespace DermaFlow.Application.Procedimentos.Commands;

// Adicione o : IRequest<Guid> logo após a declaração do record
public record CriarProcedimentoCommand(
    string Nome, 
    decimal Preco, 
    int DuracaoMinutos, 
    Guid ClinicId) : IRequest<Guid> 
{
    // Mantenha o construtor vazio se o Blazor/Serialização exigir, 
    // mas o IRequest acima é o que resolve o erro do Build.
    public CriarProcedimentoCommand() : this("", 0, 0, Guid.Empty) {}
}