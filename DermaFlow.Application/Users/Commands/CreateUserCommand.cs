using MediatR;

namespace DermaFlow.Application.Users.Commands;

// Transformando em record, o C# cria o construtor de 3 argumentos automaticamente!
public record CreateUserCommand(
    string Name, 
    string Email, 
    string Password
) : IRequest<int>; // Retorna o ID do usuário criado