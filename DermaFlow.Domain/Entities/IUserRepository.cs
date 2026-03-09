using DermaFlow.Domain.Entities;

namespace DermaFlow.Application.Interfaces;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task SaveChangesAsync();
}