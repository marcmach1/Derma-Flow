using MediatR;

namespace DermaFlow.Application.Users.Commands;

// 1. Mude de 'Name' para 'Nome' (para bater com o request.Nome do Handler)
// 2. Mude o retorno de 'int' para 'Guid' (para bater com o banco/repositório)
public record CreateUserCommand(
    string Nome, 
    string Email, 
    string Password
) : IRequest<Guid>;