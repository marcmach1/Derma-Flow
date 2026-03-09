using MediatR;
using DermaFlow.Application.Interfaces;
using DermaFlow.Domain.Entities;

namespace DermaFlow.Application.Users.Commands;

public record CreateUserCommand(string Nome, string Telefone) : IRequest<Guid>;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _repository;

    public CreateUserHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // No DDD, a entidade pode ter sua própria validação interna
        var user = new User(request.Nome, request.Telefone);
        
        await _repository.AddAsync(user);
        await _repository.SaveChangesAsync();

        return user.Id;
    }
}