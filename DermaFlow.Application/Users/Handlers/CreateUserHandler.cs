using MediatR;
using DermaFlow.Application.Users.Commands;
using DermaFlow.Application.Interfaces;
using DermaFlow.Domain.Entities;

namespace DermaFlow.Application.Users.Handlers;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _repository;

    public CreateUserHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken ct)
    {
        // Criação do objeto User
        var user = new User 
        { 
            Id = Guid.NewGuid(), 
            Name = request.Name, 
            Email = request.Email,
            Password = request.Password
        }; // <-- O Ponto e vírgula aqui é VITAL!

        // Agora sim, chamamos o repositório para salvar e retornar o Guid
        return await _repository.AdicionarAsync(user, ct);
    }
}