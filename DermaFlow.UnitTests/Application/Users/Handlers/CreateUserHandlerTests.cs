using Moq;
using Xunit;
using DermaFlow.Application.Users.Commands;
using DermaFlow.Application.Users.Handlers;
using DermaFlow.Application.Interfaces;
using DermaFlow.Domain.Entities;

namespace DermaFlow.UnitTests;

public class CreateUserHandlerTests
{
    [Fact]
    public async Task Handle_DadoComandoValido_DeveSalvarNoRepositorioERetornarId()
    {
        // 1. Arrange
        var repositoryMock = new Mock<IUserRepository>();

        // Configura o dublê para retornar o ID quando AdicionarAsync for chamado
        repositoryMock
            .Setup(r => r.AdicionarAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Guid.NewGuid());

        var handler = new CreateUserHandler(repositoryMock.Object);
        var command = new CreateUserCommand("Marc", "marc@email.com", "senha123");

        // 2. Act
        var result = await handler.Handle(command, CancellationToken.None);

        // 3. Assert
        Assert.NotEqual(Guid.Empty, result);
        repositoryMock.Verify(r => r.AdicionarAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}