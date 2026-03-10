// Local: DermaFlow.Application/Users/Handlers/CreateUserHandler.cs
using MediatR;
using DermaFlow.Application.Users.Commands;
using DermaFlow.Application.Interfaces;
using DermaFlow.Domain.Entities;

namespace DermaFlow.Application.Users.Handlers;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IUserRepository _repository;

    public CreateUserHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User { Name = request.Name, Email = request.Email };
        await _repository.AddAsync(user);
        await _repository.SaveChangesAsync();
        return user.Id;
    }
}