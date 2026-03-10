using DermaFlow.Domain.Entities;

namespace DermaFlow.Application.Interfaces;

public interface IUserRepository
{
    // 1. Padronize para o nome em português e inclua o CancellationToken
    Task<User?> ObterPorIdAsync(Guid id, CancellationToken ct);      

    // 2. Mantenha apenas este para Adicionar (que já salva e retorna o Guid)
    Task<Guid> AdicionarAsync(User user, CancellationToken ct);          
}