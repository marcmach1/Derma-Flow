using Moq;
using Xunit;
using DermaFlow.Application.Procedimentos.Commands;
using DermaFlow.Application.Procedimentos.Handlers;
using DermaFlow.Application.Interfaces;
using DermaFlow.Domain.Entities;

namespace DermaFlow.UnitTests.Application.Procedimentos.Handlers;

public class CriarProcedimentoHandlerTests
{
    [Fact]
    public async Task Handle_DadoComandoValido_DeveSalvarNoRepositorioERetornarId()
    {
        // Arrange
        var repositoryMock = new Mock<IProcedimentoRepository>();
        repositoryMock
            .Setup(r => r.AdicionarAsync(It.IsAny<Procedimento>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Guid.NewGuid());

        var handler = new CriarProcedimentoHandler(repositoryMock.Object);
        var command = new CriarProcedimentoCommand("Procedimento Teste", 100.0m, 30, Guid.NewGuid());

        // Actdo
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.NotEqual(Guid.Empty, result);
        repositoryMock.Verify(r => r.AdicionarAsync(It.IsAny<Procedimento>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
