using DermaFlow.Domain.Entities;
namespace DermaFlow.Application.Interfaces; // <-- O namespace reflete a camada Application

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);      
    Task AddAsync(User user);              
    Task SaveChangesAsync();               
}